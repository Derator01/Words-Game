using System.Text;

namespace Games.Client.Packets.PacketTypes
{
    public class WordPartPacket : Packet
    {
        public string Part { get; private set; }

        public override void LoadPacket(byte[] packetData)
        {
            Part = Encoding.UTF8.GetString(packetData);
            base.LoadPacket(packetData);
        }
    }
}
