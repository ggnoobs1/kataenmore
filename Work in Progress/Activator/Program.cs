using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Auto shield
            AutoShield.AddToMenu(Config.Menu);
           
            Config.Menu.AddToMainMenu();
        }

    }
}
