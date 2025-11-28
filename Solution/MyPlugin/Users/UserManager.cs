namespace Oxide.Plugins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TMPro;

    public partial class MyPlugin
    {
        private class UserManager
        {
            private Dictionary<string, User> Users = new Dictionary<string, User>();
            public void Init(IEnumerable<UserInfo> userInfos)
            {
                Instance.Puts("Initializing user manager...");
                var players = BasePlayer.activePlayerList;
                Dictionary<string, UserInfo> lookup;
                if (userInfos != null)
                {
                    lookup = userInfos.ToDictionary(info => info.Id, info => info);
                }
                else
                {
                    lookup = new Dictionary<string, UserInfo>();
                }
                foreach (var player in players)
                {
                    Instance.Puts($"Player: {player.displayName} ({player.UserIDString})");
                    UserInfo info = null;
                    lookup.TryGetValue(player.UserIDString, out info);
                    var user = player.gameObject.AddComponent<User>();
                    user.Init(info);
                }
                Instance.Puts($"User manager initialized");
            }

            public User[] GetAll()
            {
                return Users.Values.ToArray();
            }

            public User Get(string id)
            {
                User user;
                Users.TryGetValue(id, out user);
                return user;
            }

            public User Get(BasePlayer player)
            {
                return Get(player.UserIDString);
            }

            public User Add(BasePlayer player)
            {
                Remove()
            }

            public bool Remove(BasePlayer player)
            {
                User user = Get(player);
                if (user == null) return false;

                UnityEngine.Object.DestroyImmediate(user);
                Users.Remove(player.UserIDString);

                return true;
            }

            public void ResetAllScores()
            {
                foreach (var user in Users.Values)
                {
                    user.ResetScore();
                }
            }

            public User GetByHighestScore()
            {
                return Users.Values.OrderByDescending(user => user.Score).FirstOrDefault();
            }

            public User GetByLowestScore()
            {
                return Users.Values.OrderBy(user => user.Score).FirstOrDefault();
            }

            public void Destroy()
            {   
                foreach (var user in Users.Values)
                {
                    UnityEngine.Object.Destroy(user);
                }
                Users.Clear();
            }

            public UserInfo[] Serialize()
            {
                return Users.Values.Select(user => user.Serialize()).ToArray();
            }
        }
    }

}
