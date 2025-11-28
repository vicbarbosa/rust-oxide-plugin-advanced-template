namespace Oxide.Plugins
{
    using Oxide.Core;
    using Oxide.Core.Configuration;
    using Oxide.Core.Libraries;
    using Oxide.Core.Libraries.Covalence;
    using Oxide.Core.Plugins;
    using System;
    using System.Collections.Generic;
    using System.IO;


    [Info("MyPlugin", "Author Name", "1.0.0")]
    [Description("My plugin description")]
    public partial class MyPlugin : RustPlugin
    {
        private bool Ready = false;
        private static MyPlugin Instance;
        private DynamicConfigFile UsersFile;
        private MyPluginOptions Options; 
        private UserManager Users = new UserManager();


        private void Init()
        {
            UsersFile = GetDataFile("users");
        }

        private void Loaded()
        {
            InitLang();
            Permission.RegisterAll(this);

            try
            {
                Options = Config.ReadObject<MyPluginOptions>();
            }
            catch (Exception ex)
            {
                PrintError($"Error while loading configuration: {ex.ToString()}");
            }

            Instance = this;

            if (TerrainMeta.Size.x > 0) Setup();
        }

        private void OnServerInitialized(bool initial)
        {
            if (initial)
                Setup();
        }

        private void Unload()
        {
            SaveData();
        }

        private void Setup()
        {
            Users = new UserManager();
            Users.Init(TryLoad<UserInfo>(UsersFile));
            PrintToChat($"{Title} v{Version} initialized.");
            Ready = true;

        }

        private void OnServerSave()
        {
            SaveData();
        }

        private void SaveData()
        {
            UsersFile.WriteObject(Users.Serialize());
        }

        private IEnumerable<T> TryLoad<T>(DynamicConfigFile file)
        {
            List<T> items;

            try
            {
                items = file.ReadObject<List<T>>();
            }
            catch (Exception ex)
            {
                PrintWarning($"Error reading data from {file.Filename}: ${ex.ToString()}");
                items = new List<T>();
            }

            return items;
        }

        private void Log(string message, params object[] args)
        {
            Puts(message);
            LogToFile("log", String.Format(message, args), this, true);
        }

        private DynamicConfigFile GetDataFile(string name)
        {
            return Interface.Oxide.DataFileSystem.GetFile(Name + Path.DirectorySeparatorChar + name);
        }

        public void ChatAnnouncement(string format, params object[] args)
        {
            foreach (User user in Instance.Users.GetAll())
            {
                if (user.player)
                {
                    string message = Instance.lang.GetMessage(format, Instance, user.player.userID.ToString());
                    user.SendChatMessage(message, args);
                }
            }

        }
    }


}
