namespace Oxide.Plugins
{
    using Newtonsoft.Json;

    public partial class MyPlugin : RustPlugin
    {
        private class MyPluginOptions
        {
            [JsonProperty("subOptions1")] public SubOptions Sub = new SubOptions();

            public static MyPluginOptions Default = new MyPluginOptions
            {
                Sub = SubOptions.Default,
            };
        }

        protected override void LoadDefaultConfig()
        {
            PrintWarning("Loading default configuration.");
            Config.WriteObject(MyPluginOptions.Default, true);
        }
    }
}