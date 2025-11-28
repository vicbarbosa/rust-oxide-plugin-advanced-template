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


    [Info("MyPlugin", "yourname", "1.0.0")]
    [Description("My plugin description")]
    public partial class MyPlugin : RustPlugin
    {

        private static MyPlugin Instance;
        private DynamicConfigFile DataFile1;
        private DynamicConfigFile DataFile2;
        private DynamicConfigFile DataFile3;
        private MyPluginOptions Options; 
        private UserManager Users = new UserManager();


        private void Init()
        {
            DataFile1 = GetDataFile("datafile1");
            DataFile2 = GetDataFile("datafile2");
            DataFile3 = GetDataFile("datafile3");

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
        }

        private void OnServerSave()
        {
            SaveData();
        }

        private void SaveData()
        {
            DataFile1.WriteObject(Users.Serialize());
            //DataFile2.WriteObject(Factions.Serialize());
            //DataFile3.WriteObject(Wars.Serialize());
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
    }


}
