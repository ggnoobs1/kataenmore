#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Cassio
{
    internal class Program
    {
        private const string ChampionName = "Cassiopeia";

        private static Orbwalking.Orbwalker _orbwalker;

        private static readonly List<Spell> SpellList = new List<Spell>();
        private static Spell _q;
        private static Spell _w;
        private static Spell _e;
        private static Spell _r;
        private static SpellSlot _igniteSlot;

        private static Menu _config;

        private static bool IsPassiveReady
        {
            get
            {
                return
                    ObjectManager.Player.Buffs.Any(
                        buff =>
                            buff.IsActive && buff.Name.ToLower() == "cassiopeiadeadlycadence" &&
                            buff.EndTime <= (Game.Time + _e.Delay - 0.2 + Game.Ping / 2000.0));
            }
        }

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            if (ObjectManager.Player.ChampionName != ChampionName)
            {
                return;
            }

            _q = new Spell(SpellSlot.Q, 850);
            _w = new Spell(SpellSlot.W, 850);
            _e = new Spell(SpellSlot.E, 700);
            _r = new Spell(SpellSlot.R, 825);

            _igniteSlot = ObjectManager.Player.GetSpellSlot("SummonerDot");

            const double ultAngle = 80 * Math.PI / 180;
            const float fUltAngle = (float) ultAngle;

            _q.SetSkillshot(0.60f, 75f, int.MaxValue, false, SkillshotType.SkillshotCircle);
            _w.SetSkillshot(0.50f, 106f, 2500f, false, SkillshotType.SkillshotCircle);
            _r.SetSkillshot(0.30f, fUltAngle, int.MaxValue, false, SkillshotType.SkillshotCone);

            SpellList.Add(_q);
            SpellList.Add(_w);
            SpellList.Add(_e);

            _config = new Menu(ChampionName, ChampionName, true);

            _config.AddSubMenu(new Menu("Orbwalking", "Orbwalking"));
            _orbwalker = new Orbwalking.Orbwalker(_config.SubMenu("Orbwalking"));

            _config.AddSubMenu(new Menu("Combo", "Combo"));
            _config.SubMenu("Combo")
                .AddItem(new MenuItem("ComboActive", "Combo!").SetValue(new KeyBind(32, KeyBindType.Press)));

            _config.AddSubMenu(new Menu("Drawings", "Drawings"));
            _config.SubMenu("Drawings")
                .AddItem(
                    new MenuItem("QRange", "Q range").SetValue(new Circle(true, Color.FromArgb(255, 255, 255, 255))));
            _config.SubMenu("Drawings")
                .AddItem(
                    new MenuItem("WRange", "W range").SetValue(new Circle(false, Color.FromArgb(255, 255, 255, 255))));
            _config.SubMenu("Drawings")
                .AddItem(
                    new MenuItem("ERange", "E range").SetValue(new Circle(false, Color.FromArgb(255, 255, 255, 255))));

            _config.AddSubMenu(new Menu("Extra", "Extra"));
            _config.SubMenu("Extra")
                .AddItem(new MenuItem("Passive", "Keep Passive Up").SetValue(new KeyBind(114, KeyBindType.Toggle)));
            _config.SubMenu("Extra").AddItem(new MenuItem("Minions", "Use Q on minions").SetValue(true));
            _config.AddToMainMenu();

            Drawing.OnDraw += Drawing_OnDraw;
            Game.OnGameUpdate += Game_OnGameUpdate;
            Orbwalking.BeforeAttack += Orbwalking_BeforeAttack;
            Game.OnGameSendPacket += Game_OnGameSendPacket;
        }

        private static void Game_OnGameSendPacket(GamePacketEventArgs args)
        {
            if (args.PacketData[0] != Packet.C2S.Cast.Header)
            {
                return;
            }

            var decodedPacket = Packet.C2S.Cast.Decoded(args.PacketData);
            if (decodedPacket.SourceNetworkId != ObjectManager.Player.NetworkId || decodedPacket.Slot != SpellSlot.R)
            {
                return;
            }

            if (ObjectManager.Get<Obj_AI_Hero>().Count(hero => _r.WillHit(hero, _r.GetPrediction(hero).CastPosition)) ==
                0)
            {
                args.Process = false;
            }
        }

        private static void Orbwalking_BeforeAttack(Orbwalking.BeforeAttackEventArgs args)
        {
            args.Process = (!_q.IsReady() && !_w.IsReady() && !_e.IsReady());
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (SpellList == null)
            {
                return;
            }

            foreach (var spell in SpellList)
            {
                var menuItem = _config.Item(spell.Slot + "Range").GetValue<Circle>();

                if (menuItem.Active)
                {
                    Utility.DrawCircle(ObjectManager.Player.Position, spell.Range, menuItem.Color);
                }
            }
        }

        private static void Game_OnGameUpdate(EventArgs args)
        {
            if (_config.Item("ComboActive").GetValue<KeyBind>().Active)
            {
                ExecuteCombo();
            }

            if (_config.Item("Passive").GetValue<KeyBind>().Active)
            {
                KeepPassiveUp();
            }
        }

        private static bool IsPoisoned(Obj_AI_Base unit)
        {
            return
                unit.Buffs.Where(buff => buff.IsActive && buff.Type == BuffType.Poison)
                    .Any(buff => buff.EndTime >= (Game.Time + 0.35 + 700 / 1900));
        }

        private static void KeepPassiveUp()
        {
            if (!_q.IsReady() || !IsPassiveReady)
            {
                return;
            }

            foreach (var hero in ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsValidTarget(_q.Range)))
            {
                _q.Cast(hero, true, true);
            }

            if (_config.Item("Minions").GetValue<bool>())
            {
                foreach (
                    var minion in ObjectManager.Get<Obj_AI_Minion>().Where(minion => minion.IsValidTarget(_q.Range)))
                {
                    _q.Cast(minion, true, true);
                }
            }

            if (Game.CursorPos.Distance(ObjectManager.Player.ServerPosition) < _q.Range)
            {
                _q.Cast(Game.CursorPos);
            }
            else
            {
                _q.Cast(Game.CursorPos.To2D().Extend(ObjectManager.Player.ServerPosition.To2D(), - _q.Range + _q.Width));
            }
        }

        private static void ExecuteCombo()
        {
            var target = SimpleTs.GetTarget(_q.Range, SimpleTs.DamageType.Magical);
            if (target == null)
            {
                return;
            }

            if (_q.IsReady(2000) && _e.IsReady(2000) && _r.IsReady() &&
                DamageLib.IsKillable(
                    target,
                    new[]
                    {
                        DamageLib.SpellType.Q, DamageLib.SpellType.W, DamageLib.SpellType.E, DamageLib.SpellType.E,
                        DamageLib.SpellType.R, DamageLib.SpellType.R, DamageLib.SpellType.IGNITE
                    }))
            {
                if (_igniteSlot != SpellSlot.Unknown &&
                    ObjectManager.Player.SummonerSpellbook.CanUseSpell(_igniteSlot) == SpellState.Ready)
                {
                    ObjectManager.Player.SummonerSpellbook.CastSpell(_igniteSlot, target);
                }

                if (ObjectManager.Player.Distance(target) <= _r.Range + _r.Width)
                {
                    _r.Cast(target, true, true);
                }

                if (ObjectManager.Player.Distance(target) <= _w.Range + _w.Width)
                {
                    _w.Cast(target, true, true);
                }

                if (ObjectManager.Player.Distance(target) <= _q.Range + _q.Width)
                {
                    _q.Cast(target, true, true);
                }

                if (ObjectManager.Player.Distance(target) <= _e.Range + target.BoundingRadius && IsPoisoned(target) ||
                    DamageLib.IsKillable(target, new[] { DamageLib.SpellType.E }))
                {
                    _e.CastOnUnit(target, true);
                }
            }
            else
            {
                if (_w.IsReady() && ObjectManager.Player.Distance(target) <= _w.Range + _w.Width)
                {
                    _w.Cast(target, true, true);
                }

                if (_q.IsReady() && ObjectManager.Player.Distance(target) <= _q.Range + _q.Width)
                {
                    _q.Cast(target, true, true);
                }

                if (_e.IsReady() && ObjectManager.Player.Distance(target) <= _e.Range + target.BoundingRadius &&
                    IsPoisoned(target) || DamageLib.IsKillable(target, new[] { DamageLib.SpellType.E }))
                {
                    _e.CastOnUnit(target, true);
                }
            }
        }
    }
}