using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace Sion
{
    class Program
    {
        private static Menu Config;
        private static Obj_AI_Hero Player;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        static void Game_OnGameLoad(EventArgs args)
        {
            if (ObjectManager.Player.BaseSkinName != "Sion") return;
            Player = ObjectManager.Player;
            //Make the menu
            Config = new Menu("Sion", "Sion", true);

            var R = new Menu("R", "R");
            R.AddItem(new MenuItem("AntiCamLock", "Avoid locking camera").SetValue(true));
            R.AddItem(new MenuItem("MoveToMouse", "Move to mouse (Exploit)").SetValue(false));//Disabled by default since its not legit Keepo
            Config.AddSubMenu(R);

            Config.AddToMainMenu();

            Game.PrintChat("Sion Loaded!");
            Game.OnGameUpdate += Game_OnGameUpdate;
            Game.OnGameProcessPacket += Game_OnGameProcessPacket;
        }

        static void Game_OnGameProcessPacket(GamePacketEventArgs args)
        {
            if (args.PacketData[0] == 0xFE && Config.Item("AntiCamLock").GetValue<bool>())
            {
                args.Process = false;
            }
        }

        static void Game_OnGameUpdate(EventArgs args)
        {
            //Casting R
            if (ObjectManager.Player.HasBuff("SionR"))
            {
                if (Config.Item("MoveToMouse").GetValue<bool>())
                {
                    var p = ObjectManager.Player.Position.To2D().Extend(Game.CursorPos.To2D(), 500);
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, p.To3D());
                }
                return;
            }

            //iMehs job keepo
        }
    }
}
