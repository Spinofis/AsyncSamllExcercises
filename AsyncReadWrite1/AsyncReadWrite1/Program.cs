using System;

namespace AsyncReadWrite1
{
    class Program
    {
        static void Main(string[] args)
        {
            var textGen = new TextGenerator();
            string text = textGen.GenerateText(100000000);
            Console.WriteLine("Generated!");
            var wr = new TextReaderWriterAsync();
            wr.WriteText(@"C:\Nauka\AsyncSmallExamples\AsyncReadWrite1\AsyncReadWrite1\file.txt", text);
        }
    }
}
