using System;
using System.Collections.Generic;
using LeagueSharp.Common;

/***************************
- Anti akali/twitch
- Ward jump
***************************/

namespace Activator
{
    class Program
    {
        public static List<string> knownBuffs = new List<string>();
        public static List<string> knownLosedBuffs = new List<string>();

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += GameOnOnGameLoad;
        }

        private static void GameOnOnGameLoad(EventArgs args)
        {
            Config.Menu = new Menu("Activator", "Activator", true);

            //Auto Shield
            AutoShield.AddToMenu(Config.Menu);
            
            //Auto Potion
            AutoPotion.AddToMenu(Config.Menu);

            //Auto smite
            AutoSmite.AddToMenu(Config.Menu);
           
            Config.Menu.AddToMainMenu();
        }

    }
}
