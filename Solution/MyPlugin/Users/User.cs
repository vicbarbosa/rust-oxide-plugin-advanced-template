namespace Oxide.Plugins
{

    using UnityEngine;
    public partial class MyPlugin
    {
        private class User : MonoBehaviour
        {
            public string Name { get; private set; }
            public ulong Id { get; private set; }

            public int Score { get; private set; }

            private BasePlayer player;

            public void TryLoadInfo(UserInfo userInfo)
            {
                Name = userInfo.Name;
                Id = userInfo.Id;
                Score = userInfo.Score;
            }

            public void Init()
            {
                player = GetComponent<BasePlayer>();
            }

            public void Log()
            {
                Instance.Log($"Logged player {Name} ({Id}) {Score}");
            }

            public UserInfo Serialize()
            {
                return new UserInfo
                {
                    Name = this.Name,
                    Id = this.Id,
                    Score = this.Score
                };
            }
        }
    }
}
