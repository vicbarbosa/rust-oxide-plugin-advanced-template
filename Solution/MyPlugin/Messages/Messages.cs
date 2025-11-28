namespace Oxide.Plugins
{
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public partial class MyPlugin : RustPlugin
    {
        private static class Messages
        {
            public const string MaxScoreReached = "Player <color=#00ff00>{0}</color reached max score of {1}! Reseting all player scores!";

            public static string Get(string key, string userId = null)
            {
                return Instance.lang.GetMessage(key, Instance, userId);
            }

            public static Dictionary<string, string> AsDictionary(BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.DeclaredOnly)
            {
                var dict = typeof(Messages).GetFields().Select(f => new { Key = f.Name, Value = (string)f.GetValue(null) }).ToDictionary
                (
                    item => item.Key,
                    item => item.Value
                );
                return dict;

            }
        }

        private void InitLang()
        {
            Dictionary<string, string> messages = Messages.AsDictionary();
            lang.RegisterMessages(messages, this);

        }
    }
}