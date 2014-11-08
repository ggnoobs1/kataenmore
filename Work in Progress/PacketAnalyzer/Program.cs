#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace PacketAnalyzer
{
    internal class Packet : GamePacket
    {
        public PacketChannel Channel;
        public string Direction;
        public PacketProtocolFlags Flags;

        public Packet(GamePacketEventArgs args, string dir) : base(args)
        {
            Channel = args.Channel;
            Flags = args.ProtocolFlag;
            Direction = dir;
        }
    }

    internal static class Program
    {
        private static readonly PAForm Form1 = new PAForm();
        
        public static List<byte> BlockedRecvPackets = new List<byte> { 0x85, 0x88, 0xC4 };
        public static List<Packet> SendPackets = new List<Packet>();
        public static List<Packet> RecvPackets = new List<Packet>(); 
        public static List<byte> BlockedSendPackets = new List<byte> { 0xA8, 0x16, 0x08 }; 
        private static void Main(string[] args)
        {
            var T = new System.Threading.Thread(Work);
            T.Start();
            //   Application.Run(new PAForm);
            Game.PrintChat(((byte)SpellSlot.Recall).ToString());
            Game.OnGameSendPacket += Game_OnGameSendPacket;
            Game.OnGameProcessPacket += Game_OnGameProcessPacket;
        }

        private static void Game_OnGameProcessPacket(GamePacketEventArgs args)
        {
            if (Form1.chkRecv.Checked && !BlockedRecvPackets.Contains(args.PacketData[0]))
            {
                var p = new Packet(args, "RECV");
                Form1.PGridRecv.AddTo(p);
                RecvPackets.Add(p);
            }
        }

        private static void Game_OnGameSendPacket(GamePacketEventArgs args)
        {
            if (Form1.chkSend.Checked && !BlockedSendPackets.Contains(args.PacketData[0]))
            {
                var p = new Packet(args, "SEND");
                Form1.PGridSend.AddTo(p);
                SendPackets.Add(p);
            }
        }

        public static void Work()
        {
            Application.EnableVisualStyles();
            Application.Run(Form1);
        }

        private static void AddTo(this DataGridView view, Packet p)
        {
            Console.WriteLine("ADD TO");
            view.Rows.Add(
                new[]
                { p.Direction, p.Header.ToHexString(), p.Size().ToString(), p.Channel.ToString(), p.Flags.ToString() });
        }
    }
}