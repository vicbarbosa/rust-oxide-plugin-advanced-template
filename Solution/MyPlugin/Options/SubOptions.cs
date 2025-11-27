namespace Oxide.Plugins
{
    using Newtonsoft.Json;

    public partial class MyPlugin : RustPlugin
    {
        private class SubOptions
        {
            [JsonProperty("exampleSetting1")] public int ExampleSetting1 = 10;
            [JsonProperty("exampleSetting2")] public string ExampleSetting2 = "default value";
            public static SubOptions Default = new SubOptions
            {
                ExampleSetting1 = 10,
                ExampleSetting2 = "default value",
            };
        }
    }
}