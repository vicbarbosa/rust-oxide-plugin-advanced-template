namespace Oxide.Plugins
{
    using Newtonsoft.Json;

    public partial class MyPlugin : RustPlugin
    {
        private class MyPluginOptions
        {
            [JsonProperty("users")] public UserOptions Users = new UserOptions();

            public static MyPluginOptions Default = new MyPluginOptions
            {
                Users = UserOptions.Default,
            };
        }

        protected override void LoadDefaultConfig()
        {
            PrintWarning("Loading default configuration.");
            Config.WriteObject(MyPluginOptions.Default, true);
        }
    }
}