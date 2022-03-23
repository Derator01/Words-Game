namespace Games.Client.Packets
{
    public static class PacketUtils
    {
        public static PacketTypes.Packet GetPacket(int packetId)
        {
            return packetId switch
            {
                0 => new PacketTypes.ConnectedPacket(),
                1 => new PacketTypes.MessagePacket(),
                4 => new PacketTypes.WordPartPacket(),
                6 => new PacketTypes.AnswerTruenessPacket(),
                _ => null,
            };
        }

        public enum PacketIds : int
        {
            Connected = 0x00,
            Message = 0x01,
            WordPart = 0x4,
            AnswerTrueness = 0x6
        }
    }
}