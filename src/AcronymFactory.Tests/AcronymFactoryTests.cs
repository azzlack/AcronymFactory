namespace AcronymFactory.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class AcronymFactoryTests
    {
        private IAcronymFactory factory;

        [SetUp]
        public void SetUp()
        {
            this.factory = new AcronymFactory();
        }

        [TestCase("Fishbowl", 4)]
        [TestCase("South by Southwest", 12)]
        [TestCase("Norges  vassdrags- og energidirektorat", 8)]
        [TestCase("Statens Vegvesen", 8)]
        [TestCase("Nemo Classic Diving AS", 8)]
        [TestCase("Mellomrom", 8)]
        [TestCase("All your base are belong to us", 16)]
        [TestCase("All your base are belong to us", 6)]
        [TestCase("The flow of quizzes is interdependant on the relatedness of motivation, subcultures, and management", 50)]
        public void Create_WhenGivenSourceAndKeyLength_ShouldCreateStringWithXChars(string source, int length)
        {
            var key = this.factory.Create(source, length);

            Console.WriteLine("Output: {0}", key);

            Assert.AreEqual(length, key.Length);
        }

        [TestCase("london is free")]
        [TestCase("knowit sør")]
        [TestCase("berlingske tidende")]
        public void Create_WhenGivenSameSourceAndIdKeyType_ShouldCreateSameString(string source)
        {
            var key1 = this.factory.Create(source);
            var key2 = this.factory.Create(source);

            Console.WriteLine("Output: {0}", key1);
            Console.WriteLine("Output: {0}", key2);

            Assert.AreEqual(key1, key2);
        }
    }
}
