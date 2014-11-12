#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace PacketAnalyzer
{
    internal static class Program
    {
        private static readonly PAForm Form1 = new PAForm();

        public static List<byte> BlockedRecvPackets = new List<byte> { 0x85, 0x88, 0xC4 };
        public static List<GamePacket> SendPackets = new List<GamePacket>();
        public static List<GamePacket> RecvPackets = new List<GamePacket>();
        public static List<byte> BlockedSendPackets = new List<byte> { 0xA8, 0x16, 0x14, 0x08, 0x77 };

        [STAThread]
        private static void Main(string[] args)
        {
            var T = new System.Threading.Thread(Work);
            T.Start();

            Game.OnGameSendPacket += Game_OnGameSendPacket;
            Game.OnGameProcessPacket += Game_OnGameProcessPacket;
        }

        private static void Game_OnGameSendPacket(GamePacketEventArgs args)
        {
            if (Form1.chkSend.Checked && !BlockedSendPackets.Contains(args.PacketData[0]))
            {
                var p = new GamePacket(args);
                Form1.PGridSend.AddTo(p);
                SendPackets.Add(p);
            }
        }

        private static void Game_OnGameProcessPacket(GamePacketEventArgs args)
        {
            if (Form1.chkRecv.Checked && !BlockedRecvPackets.Contains(args.PacketData[0]))
            {
                
                var p = new GamePacket(args);
                if (p.SearchInteger(ObjectManager.Player.NetworkId) != null)
                {
                    Form1.PGridRecv.AddTo(p);
                    RecvPackets.Add(p);
                    
                }
            
            }
        
        }

        [STAThread]
        public static void SetClipboardText(ListBox list)
        {
            foreach (var item in list.Items)
            {
                Clipboard.SetText(item.ToString());
            }    
        }

        [STAThread]
        public static void Work()
        {
            Application.EnableVisualStyles();
            Form1.Show();
            //Application.Run(Form1);
        }

        private static void AddTo(this DataGridView view, GamePacket p)
        {
            view.Rows.Add(
                new object[] { p.Header.ToHexString(), p.Size().ToString(), p.Channel.ToString(), p.Flags.ToString() });
        }
    }
}