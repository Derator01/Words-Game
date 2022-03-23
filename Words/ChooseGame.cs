using System.Net;
using System.Text;

namespace Games
{
    using Client;
    using Client.Packets;
    internal static class ChooseGame
    {

        private static void Main()
        {
            Console.Title = "You're Gay anyway!";
            Console.WriteLine("Will you play online or offline?\n");

            var choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "online":
                    {
                        string[] socketArray = File.ReadAllLines(@"socket.cfg");

                        int port = -1;

                        if (IPAddress.TryParse(socketArray[0], out IPAddress ip) && !int.TryParse(socketArray[1], out port))
                            return;

                        Console.WriteLine("Connecting...\n");

                        ClientClass.Connect(ip, port);

                        Console.WriteLine("Write Your nickname\n");

                        var nickname = "";

                        while (nickname == "")
                        {
                            nickname = Console.ReadLine();
                            nickname = nickname.Replace(" ", "");
                        }

                        ClientClass.SendPacket(PacketBuilder.Build(0x2, Encoding.UTF8.GetBytes(nickname)));


                        Console.WriteLine("Are you ready?\n");
                        while (true)
                        {
                            choice = Console.ReadLine();
                            if (choice.ToLower() == "ready")
                            {
                                ClientClass.SendPacket(PacketBuilder.Build(0x3, new byte[] { 0x1 }));
                                break;
                            }
                        }

                        RealWords.Online.RealWordsGame.StartRealWordsGame();
                    }
                    break;
                case "offline":
                    {
                        while (true)
                        {
                            Console.WriteLine("Choose Game!");
                            choice = Console.ReadLine();
                            switch (choice.ToLower())
                            {
                                case "real words":
                                    {
                                        Offline.RealOfflineWordsClass.StartRealWordsGame();
                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("You're Gay!\n");
                                    }
                                    break;
                            }
                        }
                    }
            }
        }
    }
}