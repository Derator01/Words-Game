namespace Games.Client.Packets
{
    public class PacketDisassembler
    {
        static readonly ByteBuilder byteBuilder = new();

        public static PacketTypes.Packet Disassemble(byte[] inPacket)
        {
            if (inPacket.Length < 8)
                return null;
            byteBuilder.Clear();
            byteBuilder.Append(inPacket);
            int packetID = BitConverter.ToInt32(byteBuilder.GetRange(0, 4), 0);
            PacketTypes.Packet outPacket = PacketUtils.GetPacket(packetID);
            if (outPacket == null)
                return null;
            int packetSize = BitConverter.ToInt32(byteBuilder.GetRange(4, 4), 0);
            outPacket.ID = packetID;
            outPacket.PacketDataSize = packetSize;
            outPacket.LoadPacket(byteBuilder.GetRange(8, packetSize));
            return outPacket;
        }
    }
}
