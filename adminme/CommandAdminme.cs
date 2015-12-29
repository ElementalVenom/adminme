using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Core;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket;
using Rocket.Unturned.Chat;

namespace AdminMe
{
    class CommandAdminme : IRocketCommand
    {
        public string Name
        {
            get { return "adminme"; }
        }
        public string Help
        {
            get { return "Gives a player admin"; }
        }
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }
        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Player; }
        }
        public string Syntax
        {
            get { return ""; }
        }
        public List<string> Permissions
        {
            get
            {
                return new List<string>()
                {
                    "adminme",
                };
            }
        }
        public void Execute(Rocket.API.IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (player.HasPermission("adminme"))
            {
                if (player.IsAdmin)
                {
                    player.Admin(false);
                    player.GodMode = false;
                    player.VanishMode = false;
                    UnturnedChat.Say(player.CharacterName + " is now off duty.", UnityEngine.Color.red);
                }
                else
                {
                    player.Admin(true);
                    player.GodMode = true;
                    UnturnedChat.Say(player.CharacterName + " is now on duty.", UnityEngine.Color.red);
                }
            }
        }
    }
}
