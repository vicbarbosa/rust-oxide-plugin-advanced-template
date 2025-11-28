namespace Oxide.Plugins
{
    using Network;
    using Oxide.Core;
    using UnityEngine;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using Rust.Ai;
    public partial class MyPlugin: RustPlugin
    {

        private void OnPlayerConnected(BasePlayer player)
        {
            if (player == null) return;

            // If the player hasn't fully connected yet, try again in 2 seconds.
            if (player.IsReceivingSnapshot)
            {
                timer.In(2, () => OnPlayerConnected(player));
                return;
            }
            Users.Add(player);
        }

        private void OnPlayerDisconnected(BasePlayer player)
        {
            if (player != null)
                Users.Remove(player);
        }
    }
}