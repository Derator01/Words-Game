namespace Games.Client.Packets.PacketTypes
{
    public class Packet
    {
        public int ID { get; internal set; }
        public int PacketDataSize { get; internal set; }
        public byte[] PacketData { get; private set; }

        public virtual void LoadPacket(byte[] packetData) { }
    }
}