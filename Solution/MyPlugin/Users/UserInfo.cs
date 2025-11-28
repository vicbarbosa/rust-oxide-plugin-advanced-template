

namespace Oxide.Plugins
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class MyPlugin
    {
        private class UserInfo
        {
            [JsonProperty("id")] public string Id { get; set; } = "";
            [JsonProperty("name")] public string Name { get; set; } = "unknown";
            [JsonProperty("score")] public int Score { get; set; } = 0;
        }
    }
}
