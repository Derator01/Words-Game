using System.Text;

namespace Games.RealWords.Online
{
    internal class RealWordsGame
    {
        internal static async void StartRealWordsGame()
        {
            while (!Client.ClientClass.CanContinue)
            {
                await Task.Delay(1);
            }

            Console.WriteLine("\nYou can enter your guess\n");

            while (true)
            {
                Client.ClientClass.SendPacket(Client.Packets.PacketBuilder.Build(0x5, Encoding.UTF8.GetBytes(Console.ReadLine())));


                while (!Client.ClientClass.CanContinue)
                {
                    await Task.Delay(1);
                }

                if (Client.ClientClass.AnswerTrueness)
                {
                    break;
                }
            }
        }
    }
}
