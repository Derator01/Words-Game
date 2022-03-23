namespace Games.Client.Packets
{
    public class PacketBuilder
    {
        public static byte[] Build(int packetId, byte[] packetData)
        {
            ByteBuilder bb = new();
            bb.Append(BitConverter.GetBytes(packetId));
            bb.Append(BitConverter.GetBytes(packetData.Length));
            bb.Append(packetData);
            bb.Append(ClientClass._packetEnding);
            return bb.ToArray();
        }

        //public byte[] BuildWithoutEnding(int packetId, byte[] packetData)
        //{
        //    ByteBuilder bb = new ByteBuilder();
        //    bb.Append(BitConverter.GetBytes(packetId));
        //    bb.Append(BitConverter.GetBytes(packetData.Length));
        //    bb.Append(packetData);
        //    return bb.ToArray();
        //}
    }
}
