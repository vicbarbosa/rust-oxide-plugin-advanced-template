namespace Oxide.Plugins
{
    using Newtonsoft.Json;

    public partial class MyPlugin : RustPlugin
    {
        private class UserOptions
        {
            [JsonProperty("maxScore")] public int MaxScore { get; set; }
            public static UserOptions Default = new UserOptions
            {
                MaxScore = 100,
            };
        }
    }
}