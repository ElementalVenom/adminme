using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using UnityEngine;
using Rocket.API;
using System;

namespace AdminMe
{
    public class AdminMe : RocketPlugin
    {
        public static AdminMe Instance;
        protected override void Load()
        {
            U.Events.OnPlayerConnected += PlayerConnected;
            U.Events.OnPlayerDisconnected += PlayerDisconnected;
            Instance = this;
        }
        void PlayerConnected(UnturnedPlayer player)
        {
            if (player.IsAdmin)
            {
                player.GodMode = false;
                player.VanishMode = false;
                player.Admin(false);
            }
        }
        void PlayerDisconnected(UnturnedPlayer player)
        {
            if (player.IsAdmin)
            {
                player.GodMode = false;
                player.VanishMode = false;
                player.Admin(false);
            }
        }
    }
}
