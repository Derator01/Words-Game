namespace Games.Offline
{
    internal class RealWordsClass : WordsHold
    {
        private readonly Random rnd = new();

        private bool _initialized = false;

        internal RealWordsClass()
        {
            InitHold();
        }

        internal string GetRandomWord()
        {
            if (!_initialized)
                return null;
            return words[rnd.Next(words.Count)];
        }

        internal bool CheckStr(string str)
        {
            if (!_initialized)
                return false;
            return words.Contains(str);
        }
    }
}