using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using Color = System.Drawing.Color;

namespace Activator
{
    public static class AutoSmite
    {
        public struct SpellStruct
        {
            public string ChampionName;
            public SpellSlot Slot;
        }

        public static List<SpellStruct> SpellList = new List<SpellStruct>();
        public static Obj_AI_Hero Player = ObjectManager.Player;
        public static SpellSlot SmiteSlot;
        public static SpellSlot SpellSlot;

        static AutoSmite()
        {
            Game.OnGameUpdate += Game_OnGameUpdate;
            Drawing.OnDraw += Drawing_OnDraw;

            SmiteSlot = Player.GetSpellSlot("SummonerSmite");

            #region Olaf
            SpellList.Add(new SpellStruct
            {
                ChampionName = "Olaf",
                Slot = SpellSlot.E
            });
            #endregion

            #region Nunu
            SpellList.Add(new SpellStruct
            {
                ChampionName = "Nunu",
                Slot = SpellSlot.Q
            });
            #endregion

            foreach (var spell in SpellList)
            {
                if (spell.ChampionName == Player.ChampionName)
                {
                    SpellSlot = spell.Slot;
                }
            }
        }

        public static void AddToMenu(Menu menu)
        {
            var smiteMenu = new Menu("Auto Smite", "AutoSmite");

            smiteMenu.AddItem(new MenuItem("AutoSmiteEnabled", "Enabled").SetValue(true));
            smiteMenu.AddItem(new MenuItem("EnableSmallCamps", "Smite small Camps").SetValue(true));
            smiteMenu.AddItem(new MenuItem("AutoSmiteDrawing", "Enable Drawing").SetValue(true));

            menu.AddSubMenu(smiteMenu);
        }

        //Get Monster
        private static readonly string[] MinionNames =
        {
            "Worm", "Dragon", "LizardElder", "AncientGolem", "TT_Spiderboss", "TTNGolem", "TTNWolf", "TTNWraith"
        };

        private static readonly string[] SmallMinionNames =
        {
            //Andre add small camps
        };

        private static Obj_AI_Base GetMinion()
        {
            var minionList = MinionManager.GetMinions(Player.ServerPosition, 500, MinionTypes.All, MinionTeam.Neutral);
            var smallCamps = Config.Menu.Item("EnableSmallCamps").GetValue<bool>();
            return smallCamps
                ? minionList.FirstOrDefault(
                    minion => minion.IsValidTarget(500) && MinionNames.Any(name => minion.Name.StartsWith(name)) && SmallMinionNames.Any(smallname => minion.Name.StartsWith(smallname)))
                : minionList.FirstOrDefault(
                    minion => minion.IsValidTarget(500) && MinionNames.Any(name => minion.Name.StartsWith(name)));
        }

        //Cast Smite
        private static void CastSmite(GameObject unit)
        {
            if (SmiteSlot != SpellSlot.Unknown && Player.SummonerSpellbook.CanUseSpell(SmiteSlot) == SpellState.Ready)
            {
                Player.SummonerSpellbook.CastSpell(SmiteSlot, unit);
            }
        }

        //Kill monster
        private static void KillMinion(Obj_AI_Base minion)
        {
            if (SmiteSlot != SpellSlot.Unknown && Player.SummonerSpellbook.CanUseSpell(SmiteSlot) == SpellState.Ready &&
                Player.Spellbook.CanUseSpell(SpellSlot) == SpellState.Ready)
            {
                if (Player.GetSummonerSpellDamage(minion, Damage.SummonerSpell.Smite) +
                    Player.GetSpellDamage(minion, SpellSlot) > minion.Health)
                {
                    CastSmite(minion);
                    Player.Spellbook.CastSpell(SpellSlot, minion);
                }
            }
            else if (SmiteSlot != SpellSlot.Unknown &&
                     Player.SummonerSpellbook.CanUseSpell(SmiteSlot) == SpellState.Ready &&
                     Player.Spellbook.CanUseSpell(SpellSlot) == SpellState.Ready)
            {
                if (Player.GetSummonerSpellDamage(minion, Damage.SummonerSpell.Smite) > minion.Health ||
                    Player.GetSpellDamage(minion, SpellSlot) > minion.Health)
                {
                    CastSmite(minion);
                    Player.Spellbook.CastSpell(SpellSlot, minion);
                }
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