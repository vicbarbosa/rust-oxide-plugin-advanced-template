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
            public void Init(IEnumerable<UserInfo> areaInfos)
            {
                Instance.Puts("Initializing user manager...");

                Instance.Puts($"User manager initialized");
            }
        }
    }

}
