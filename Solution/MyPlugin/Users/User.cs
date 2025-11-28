namespace Oxide.Plugins
{

    using UnityEngine;
    public partial class MyPlugin
    {
        private class User : MonoBehaviour
        {
            public string Name { get; private set; }
            public string Id { get; private set; }

            public int Score { get; private set; }

            public BasePlayer player;

            public void TryLoadInfo(UserInfo userInfo)
            {
                Name = userInfo.Name;
                Id = userInfo.Id;
                Score = userInfo.Score;
            }

            public void Init(UserInfo? info)
            {
                player = GetComponent<BasePlayer>();

                if(info == null)
                {
                    Name = player.displayName;
                    Id = player.UserIDString;
                    Score = 0;
                }
                else
                {
                    TryLoadInfo(info);
                }
            }

            public void SendChatMessage()
            {
                player.ChatMessage($"User Info - Name: {Name}, Id: {Id}, Score: {Score}");
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
