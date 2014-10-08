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
        public bool IsMelee;
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
            #region Annie

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Annie",
                    IsCC = true,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "InfernalGuardian"
                });

            #endregion
            #region Brand

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Brand",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "BrandWildfire"
                });

            #endregion
            #region Fiddlesticks

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Fiddlesticks",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "Crowstorm"
                });

            #endregion
            #region Fiora

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Fiora",
                    IsCC = false,
                    IsMelee = true,
                    Slot = SpellSlot.R,
                    SpellName = "FioraDance"
                });
            
            #endregion
            #region Graves

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Graves",
                    IsCC = false,
                    IsMelee = true,
                    Slot = SpellSlot.R,
                    SpellName = "GravesChargeShot"
                });

            #endregion
            #region Katarina

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Katarina",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "KatarinaR"
                });

            #endregion
            #region Kennen

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Kennen",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "KennenShurikenStorm"
                });

            #endregion
            #region Lissandra

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Lissandra",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "LissandraR"
                });

            #endregion
            #region Lux

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Lux",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "LuxMaliceCannon"
                });

            #endregion
            #region Malzahar

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Malzahar",
                    IsCC = true,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "AlZaharNetherGrasp"
                });

            #endregion
            #region MissFortune

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "MissFortune",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "MissFortuneBulletTime"
                });

            #endregion
            #region Morgana

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Morgana",
                    IsCC = true,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "SoulShackles"
                }); //NEEDS DELAY

            #endregion
            #region Nunu

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Nunu", 
                    IsCC = true,
                    IsMelee = true,
                    Slot = SpellSlot.R, 
                    SpellName = "AbsoluteZero"
                });

            #endregion
            #region Orianna

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Orianna",
                    IsCC = true,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "OrianaDetonateCommand"
                });

            #endregion
            #region Riven

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Riven",
                    IsCC = false,
                    IsMelee = true,
                    Slot = SpellSlot.R,
                    SpellName = "RivenFengShuiEngine"
                });

            #endregion
            #region Syndra

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Syndra",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "SyndraR"
                });

            #endregion
            #region Tristana

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Tristana",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "BusterShot"
                });

            #endregion
            #region Twitch

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Twitch",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "FullAutomatic"
                });

            #endregion
            #region Veigar

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Veigar",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "VeigarPrimordialBurst"
                });

            #endregion
            #region Velkoz

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Velkoz",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "VelkozR"
                });

            #endregion
            #region Vi

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Vi",
                    IsCC = true,
                    Slot = SpellSlot.R,
                    SpellName = "ViR"
                });

            #endregion
            #region Viktor

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Viktor",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "ViktorChaosStorm"
                });

            #endregion
            #region MonkeyKing

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "MonkeyKing",
                    IsCC = false,
                    IsMelee = true,
                    Slot = SpellSlot.R,
                    SpellName = "MonkeyKingSpinToWin"
                });

            #endregion
            #region Xerath

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Xerath",
                    IsCC = false,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "XerathLocusOfPower2"
                });

            #endregion
            #region Yasuo

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Yasuo",
                    IsCC = false,
                    IsMelee = true,
                    Slot = SpellSlot.R,
                    SpellName = "YasuoRKnockUpComboW"
                });
            #endregion
            #region Zed

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Zed",
                    IsCC = false,
                    IsMelee = true,
                    Slot = SpellSlot.R,
                    SpellName = "ZedUlt"
                });

            #endregion
            #region Zyra

            Spells.Add(
                new SpellToExhaust
                {
                    ChampionName = "Zyra",
                    IsCC = true,
                    IsMelee = false,
                    Slot = SpellSlot.R,
                    SpellName = "ZyraBrambleZone"
                });

            #endregion

            Game.OnGameUpdate += Game_OnGameUpdate;
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
        }

        private static void Game_OnGameUpdate(EventArgs args)
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