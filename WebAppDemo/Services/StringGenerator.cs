namespace WebAppDemo.Services
{
    public class StringGenerator
    {
        private int _nbChars = 0;

        public StringGenerator(int nbChars = 1000)
        {
            _nbChars = nbChars;
        }

        public string Generate()
        {
            var currentStr = "";
            var rnd = new Random();
            for (int i=0; i < _nbChars; i++)
            {
                currentStr += (char)rnd.Next(48,123);
            }

            return currentStr;
        }
    }
}
