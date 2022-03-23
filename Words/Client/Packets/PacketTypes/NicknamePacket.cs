using System.Text;

namespace Games.Client.Packets.PacketTypes
{
    public class NicknamePacket : Packet
    {
        public string Nick { get; private set; }

        public override void LoadPacket(byte[] packetData)
        {
            Nick = Encoding.UTF8.GetString(packetData);
            base.LoadPacket(packetData);
        }
    }
}
