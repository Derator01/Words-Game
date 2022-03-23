namespace Games.Offline
{
    internal class WordsGameClass
    {
        static readonly char[] _rusLetters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'э', 'ю', 'я' };

        internal static void StartWordsGame()
        {
            Random r = new();

            while (true)
            {
                int turns = 0;

                bool cantEscape = true;
                while (cantEscape)
                {
                    cantEscape = false;
                    try
                    {
                        turns = int.Parse(Console.ReadLine());
                        if (turns < 2)
                            throw new ArgumentOutOfRangeException();
                    }
                    catch
                    {
                        cantEscape = true;
                    }
                }

                Console.WriteLine();

                int currentTurn = 1;

                while (true)
                {
                    int hp = 10;
                    while (true)
                    {
                        Console.WriteLine($"Turn: {currentTurn}\nYour HP = {hp}\n");

                        string wordPart;
                        int length = _rusLetters.Length;

                        wordPart = _rusLetters[r.Next(length)].ToString();
                        wordPart += _rusLetters[r.Next(length)];
                        wordPart += _rusLetters[r.Next(length)];

                        Console.WriteLine(wordPart);


                        var command = Console.ReadLine();

                        if (command == "+")
                        {
                            if (currentTurn == turns)
                                currentTurn = 1;
                            else
                                currentTurn++;

                            break;
                        }
                        else
                        {
                            if (hp < 2)
                            {
                                Console.WriteLine(currentTurn + ", you lost!");
                                return;
                            }
                            hp--;
                        }
                    }
                }
            }
        }
    }
}
