using System;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using Color = System.Drawing.Color;

namespace Activator
{
    public static class AutoSmite
    {
        private static SpellSlot SmiteSlot;
        private static Obj_AI_Hero Player = ObjectManager.Player;
        static AutoSmite()
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
            Drawing.OnDraw += Drawing_OnDraw;

            SmiteSlot = Player.GetSpellSlot("SummonerSmite");
        }

        public static void AddToMenu(Menu menu)
        {
            var smiteMenu = new Menu("Auto Smite", "AutoSmite");

            smiteMenu.AddItem(new MenuItem("AutoSmiteEnabled", "Enabled").SetValue(true));
            smiteMenu.AddItem(new MenuItem("AutoSmiteDrawing", "Enable Drawing").SetValue(true));

            menu.AddSubMenu(smiteMenu);
        }

        //Get Monster
        private static readonly string[] MinionNames =
        {
            "Worm", "Dragon", "LizardElder", "AncientGolem", "TT_Spiderboss", "TTNGolem", "TTNWolf", "TTNWraith"
        };

        private static Obj_AI_Base GetMinion()
        {
            var minionList = MinionManager.GetMinions(Player.ServerPosition, 500, MinionTypes.All, MinionTeam.Neutral);
            return minionList.FirstOrDefault(minion => minion.IsValidTarget(500) && MinionNames.Any(name => minion.Name.StartsWith(name)));
        }

        //Kill monster
        private static void KillMinion(Obj_AI_Base minion)
        {
            if (SmiteSlot != SpellSlot.Unknown && Player.SummonerSpellbook.CanUseSpell(SmiteSlot) == SpellState.Ready &&
                Player.GetSummonerSpellDamage(minion, Damage.SummonerSpell.Smite) > minion.Health)
            {
                Player.SummonerSpellbook.CastSpell(SmiteSlot, minion);
            }
        }

        public static void Game_OnGameUpdate(EventArgs args)
        {
            if (!Config.Menu.Item("AutoSmiteEnabled").GetValue<bool>())
                return;

            var minion = GetMinion();
            if (minion != null)
            {
                KillMinion(minion);
            }
        }

        public static void Drawing_OnDraw(EventArgs args)
        {
            if (!Config.Menu.Item("AutoSmiteEnabled").GetValue<bool>() || !Config.Menu.Item("AutoSmiteDrawing").GetValue<bool>())
                return;

            Utility.DrawCircle(Player.Position, 700, Color.Coral);
        }
    }
}