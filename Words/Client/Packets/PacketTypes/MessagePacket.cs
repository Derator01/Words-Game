using System.Text;

namespace Games.Client.Packets.PacketTypes
{
    public class MessagePacket : Packet
    {
        public string Text { get; private set; }

        public override void LoadPacket(byte[] packetData)
        {
            Text = Encoding.UTF8.GetString(packetData);
            base.LoadPacket(packetData);
        }
    }
}
