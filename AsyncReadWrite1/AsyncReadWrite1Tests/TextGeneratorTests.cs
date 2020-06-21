using AsyncReadWrite1;
using NUnit.Framework;
using System.Linq;

namespace AsyncReadWrite1Tests
{
    public class TextGeneratorTests
    {
        private TextGenerator textGen;

        [SetUp]
        public void Setup()
        {
            textGen = new TextGenerator();
        }

        [Test]
        public void GenerateText_ShouldReturnStringWithSpecifiedLength()
        {
            var res = textGen.GenerateText(100);

            Assert.That(res.Count, Is.EqualTo(100));
        }
    }
}