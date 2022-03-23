namespace Games.Offline
{
    internal class RealOfflineWordsClass
    {
        private static readonly Random rnd = new();

        public static void StartRealWordsGame()
        {
            if (!WordsHold.InitHold())
            {
                Console.WriteLine("Go To Hell! There is non such file!");
                return;
            }
            while (true)
            {
                string word = WordsHold.words[rnd.Next(WordsHold.words.Count)];

                int firstLetter = rnd.Next(word.Length - 2);
                Console.WriteLine(new string(new char[] { word[firstLetter], word[firstLetter + 1], word[firstLetter + 2] }));

                if (WordsHold.words.Contains(Console.ReadLine().ToLower()))
                {
                    Console.WriteLine("You're lucky. You're not gay yet!");
                }
                else
                {
                    Console.WriteLine("You're Gay!");
                }
            }
        }
    }
}
