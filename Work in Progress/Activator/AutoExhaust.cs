#region

using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Activator
{
    public struct SpellToExhaust
    {
        public string ChampionName;
        public bool IsCC;
        public SpellSlot Slot;
        public string SpellName;
    }

    public struct ActiveSpellToExhaust
    {
        public Obj_AI_Hero Sender;
        public string SpellName;
        public int TickCount;
    }

    internal class AutoExhaust
    {
        public static List<SpellToExhaust> Spells = new List<SpellToExhaust>();
        public static List<ActiveSpellToExhaust> ActiveSpells = new List<ActiveSpellToExhaust>();

        static AutoExhaust()
        {
            #region Zed

            Spells.Add(
                new SpellToExhaust { ChampionName = "Zed", IsCC = false, Slot = SpellSlot.R, SpellName = "ZedUlt" });

            #endregion

            Game.OnGameUpdate += Game_OnGameUpdate;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Game_OnGameUpdate(System.EventArgs args)
        {
            ActiveSpells.RemoveAll(entry => Environment.TickCount > entry.TickCount + 1500);

            foreach (var spell in
                ActiveSpells.Where(
                    spell =>
                        spell.Sender.IsValidTarget(650f) &&
                        spell.Sender.LastCastedSpellName().ToLower() == spell.SpellName.ToLower()))
            {
                CastExhaust(spell.Sender);
            }
        }

        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!SpellShouldBeExhausted(args))
            {
                return;
            }

            ActiveSpells.Add(
                new ActiveSpellToExhaust
                {
                    Sender = (Obj_AI_Hero) sender,
                    SpellName = args.SData.Name,
                    TickCount = Environment.TickCount
                });
        }

        private static void CastExhaust(GameObject unit)
        {
            var exhaustSlot = ObjectManager.Player.GetSpellSlot("SummonerExhaust");

            if (exhaustSlot != SpellSlot.Unknown &&
                ObjectManager.Player.SummonerSpellbook.CanUseSpell(exhaustSlot) == SpellState.Ready)
            {
                ObjectManager.Player.SummonerSpellbook.CastSpell(exhaustSlot, unit);
            }
        }

        private static bool SpellShouldBeExhausted(GameObjectProcessSpellCastEventArgs args)
        {
            return Spells.Any(spell => spell.SpellName.ToLower() == args.SData.Name.ToLower());
        }
    }
}