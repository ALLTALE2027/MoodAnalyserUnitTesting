using MoodAnalyserUnitTests;

namespace TestMoodAnalyser
{
    public class Tests
    {
        MoodAnalyser moodanalyzer;
        [SetUp]
        public void Setup()
        {
            moodanalyzer = new MoodAnalyser();
        }

        [Test]
        public void Given_Sad_Return_Sad_Default_constructor()
        {
            moodanalyzer = new MoodAnalyser();
            string message = "I am in Sad mood";
            string result = moodanalyzer.AnalysisMoodWithDefaultConstructor(message);
            Assert.AreEqual("SAD", result);
        }
        [Test]
        public void Given_Happy_Return_Happy_Default_constructor()
        {
            moodanalyzer = new MoodAnalyser();
            string message = "I am in HAPPY mood";
            string result = moodanalyzer.AnalysisMoodWithDefaultConstructor(message);
            Assert.AreEqual("HAPPY", result);
        }
        [Test]
        public void Given_Sad_Return_Sad_Parameterised_constructor()
        {
            moodanalyzer = new MoodAnalyser("I am in Sad mood");
            string result = moodanalyzer.AnalysisMoodWithParameterisedConstructor();
            Assert.AreEqual("SAD", result);
        }

        [Test]
        public void Given_Happy_Return_Happy_Parameterised_constructor()
        {
            string message = "I am in Happy mood";
            moodanalyzer = new MoodAnalyser(message);
            string result = moodanalyzer.AnalysisMoodWithParameterisedConstructor();
            Assert.AreEqual("HAPPY", result);
        }

    }
}