using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsyncReadWrite1
{

    public class TextGenerator
    {
        const int MAX_WORD_LEN = 12;

        private readonly Random _wordRandom = new Random();

        private readonly Random _charRandom = new Random();

        public string GenerateText(double length)
        {
            List<string> alphabeth = Enumerable.Range(97, 26)
                .Select(x => Char.ConvertFromUtf32(x))
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString());

            while (length > 0)
            {
                double wordLength = _wordRandom.Next(1, MAX_WORD_LEN);
                wordLength = length < wordLength ? length : wordLength;
                length -= wordLength;
                sb.Append(GetWord(wordLength, alphabeth));
            }

            return sb.ToString();
        }

        private string GetWord(double length, List<string> alphabeth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length - 1; i++)
                sb.Append(alphabeth[_charRandom.Next(25)]);
            sb.Append(' ');
            return sb.ToString();
        }
    }
}
