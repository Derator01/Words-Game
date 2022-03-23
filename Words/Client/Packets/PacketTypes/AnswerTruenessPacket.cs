namespace Games.Client.Packets.PacketTypes
{
    public class AnswerTruenessPacket : Packet
    {
        public bool Trueness { get; set; }

        public override void LoadPacket(byte[] packetData)
        {
            Trueness = packetData[0].Equals(0x01);
            base.LoadPacket(packetData);
        }
    }
}
