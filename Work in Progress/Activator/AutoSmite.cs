using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace Activator
{
    public static class AutoSmite
    {
        public static void AddToMenu(Menu menu)
        {
            var smiteMenu = new Menu("AutoSmite", "AutoSmite");
            
            menu.AddSubMenu(smiteMenu);
        }
    }
}
