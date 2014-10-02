using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace Activator
{
    class AutoPotion
    {
        private enum PotionType {
            Health,
            Mana
        }

        static AutoPotion()
        {
            Game.OnGameUpdate += OnGameUpdate;
        }

        public static void AddToMenu(Menu menu)
        {
            var potionsMenu = new Menu("Auto Potion", "AutoPotion");

            potionsMenu.AddItem(new MenuItem("HpPct", "Health %").SetValue(new Slider(40)));
            potionsMenu.AddItem(new MenuItem("MnPct", "Mana %").SetValue(new Slider(20)));

            menu.AddSubMenu(potionsMenu);
        }

        private static void OnGameUpdate(EventArgs args)
        {
            var Player = ObjectManager.Player;

            // Default Potions
            float _HpPct = Config.Menu.Item("HpPct").GetValue<Slider>().Value / 100f;
            float _MnPct = Config.Menu.Item("MnPct").GetValue<Slider>().Value / 100f;

            // Flask
            if (Player.HasBuff("ItemCrystalFlask"))
                return;

            // Health Potion
            if (Player.Health / Player.MaxHealth <= _HpPct && !Player.HasBuff("Health Potion"))
                CastPotion(PotionType.Health);

            // Mana Potion
            if (Player.Mana / Player.MaxMana <= _MnPct && !Player.HasBuff("Mana Potion"))
                CastPotion(PotionType.Mana);

        }

        private static void CastPotion(PotionType type)
        {
            ObjectManager.Player.InventoryItems.Where(item => item.Id == (type == PotionType.Health ? (ItemId)2003 : (ItemId)2004) || (item.Id == (ItemId)2041 && item.Charges > 0)).First().UseItem();
        }
    }
}
