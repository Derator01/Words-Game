namespace Games.Offline
{
    internal class WordsHold
    {
        internal static List<string> words = new();

        private static readonly string _path = "RusDictionary.txt";

        internal static bool InitHold()
        {
            try
            {
                words = new List<string>(File.ReadAllLines(_path));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
