

namespace Oxide.Plugins
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class MyPlugin
    {
        private class UserInfo
        {
            [JsonProperty("id")] public ulong Id { get; set; } = 0;
            [JsonProperty("name")] public string Name { get; set; } = "unknown";
            [JsonProperty("score")] public int Score { get; set; } = 0;
        }
    }
}
