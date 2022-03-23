using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Games.Client
{
    using Packets;
    using Packets.PacketTypes;
    internal class ClientClass
    {
        public static bool IsRunning = false;
        public static readonly byte[] _packetEnding = new byte[] { 0xFF, 0x00, 0xFA, 0xAF, 0xAA };
        public static readonly byte[] _buffer = new byte[4096];
        private static ByteBuilder byteBuilder = new();

        private static Thread _thread;

        private static bool _canContinue;
        public static bool AnswerTrueness;

        public static bool CanContinue
        {
            get
            {
                if (_canContinue)
                {
                    _canContinue = !_canContinue;
                    return true;
                }
                return false;
            }
            private set
            {
                _canContinue = value;
            }
        }

        internal static string _id = "26.107.70.17";
        internal static int _port = 8921;

        internal static TcpClient client;
        internal static bool Connect(IPAddress ip, int port)
        {
            if (IsRunning)
                return false;
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
                return false;
            }
            _thread = new Thread(ClientLoop);
            _thread.Start();
            IsRunning = true;
            return true;
        }

        internal static void Disconnect()
        {
            if (!IsRunning)
                return;
            IsRunning = false;
            try
            {
                client.GetStream().Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal static void SendPacket(byte[] packet)
        {
            if (!IsRunning)
                return;
            try
            {
                client.GetStream().Write(packet, 0, packet.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
                return;
            }
        }

        internal static void ClientLoop()
        {
            try
            {
                while (IsRunning)
                {
                    int count = client.GetStream().Read(_buffer, 0, _buffer.Length);
                    if (count < 1)
                    {
                        Disconnect();
                        return;
                    }
                    else
                    {
                        byte[] bytes = _buffer;
                        Array.Resize(ref bytes, count);
                        CheckBytes(bytes);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void CheckBytes(byte[] data)
        {
            byteBuilder.Append(data);
            if (byteBuilder.EndsWith(_packetEnding))
            {
                int i = -1;
                while ((i = byteBuilder.IndexOf(_packetEnding)) != -1)
                {
                    OnIncomingPacket(byteBuilder.GetRange(0, i + _packetEnding.Length));
                    byteBuilder.RemoveFirstElements(i + _packetEnding.Length);
                }
                byteBuilder.Clear();
            }
        }

        private static void OnIncomingPacket(byte[] packet)
        {
            //Console.WriteLine(ByteBuilder.ToString(packet));

            Packet disassembled = PacketDisassembler.Disassemble(packet);
            if (disassembled == null)
                return;

            if (disassembled.GetType().Equals(typeof(ConnectedPacket)))
            {
                Console.WriteLine("Now, you're not lonely gay!\n");
            }
            if (disassembled.GetType().Equals(typeof(MessagePacket)))
            {
                Console.WriteLine(((MessagePacket)disassembled).Text + "\n");
            }
            if (disassembled.GetType().Equals(typeof(WordPartPacket)))
            {
                Console.WriteLine(((WordPartPacket)disassembled).Part + "\n");
                CanContinue = true;
            }
            if (disassembled.GetType().Equals(typeof(AnswerTruenessPacket)))
            {
                bool trueness = ((AnswerTruenessPacket)disassembled).Trueness;

                Console.WriteLine("You're " + ((trueness ? "not Gay yet!" : "Gay!\n")));
                AnswerTrueness = trueness;
                CanContinue = true;
            }
        }
    }
}
