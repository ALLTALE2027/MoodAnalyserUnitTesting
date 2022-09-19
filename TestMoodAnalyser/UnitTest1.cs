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
        [Test]
        public void if_Null_message_throw_happy()
        {
            moodanalyzer = new MoodAnalyser();
            try
            {
                string Message = moodanalyzer.AnalyseMoodException();
            }
            catch (MoodAnalyserNull mood)
            {
                Assert.AreEqual("HAPPY", mood.IsHappy);
            }
        }
        [Test]
        public void GiveMessage_WhenNull_UsingCustomException_shouldReturnNullMood()
        {

            moodanalyzer = new MoodAnalyser();
            try
            {
                string Message = moodanalyzer.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NULL_MOOD, exception.exceptionType);
            }
        }
        [Test]
        public void GiveMessage_WhenEmpty_UsingCustomException_shouldReturnEmptyMood()
        {

            moodanalyzer = new MoodAnalyser("");
            try
            {
                string Message = moodanalyzer.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EMPTY_MOOD, exception.exceptionType);
            }
        }

        [Test]
        public void CreateMoodAnalyser_GivenProperMoodanalyzerClassName_ShouldReturnMoodanalyzerObject()
        {
            //object expected = new Moodanalyzer();
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserUnitTests.MoodAnalyser", "MoodAnalyser");
            Assert.IsInstanceOf(typeof(MoodAnalyser), obj);
        }
        [Test]
        public void CreateMoodAnalyser_GivenInProperClassName_ShouldReturnNoSuchClass()
        {
            try
            {
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.MoodAnalyser", "MoodAnalyser");
                expected.Equals(obj);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_CLASS_FOUND, exception.exceptionType);
            }
        }
        [Test]
        public void CreateMoodAnalyser_GivenInProperConstructorName_ShouldReturnNoSuchConstructor()
        {
            try
            {
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserUnitTests.MoodAnalyzer", "Moodanalyser");
                expected.Equals(obj);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_CONSTRUCTOR_FOUND, exception.exceptionType);
            }
        }

        [Test]
        public void
           CreateMoodAnalyserUsingParametrisedConstructor_GivenProperClassName_shouldReturnMoodAnalyserObject()
        {
            string message = "Today I am happy";
            //object expected = new Moodanalyzer(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParametrisedConstructor("MoodAnalyserUnitTests.MoodAnalyser", "MoodAnalyser", message);
            Assert.IsInstanceOf(typeof(MoodAnalyser), obj);
        }

        [Test]
        public void
            CreateMoodAnalyserUsingParametrisedConstructor_GivenInProperClassName_shouldReturnClassNotFound()
        {
            try
            {
                string message = "Today I am happy";
                object expected = new MoodAnalyser(message);
                object obj =MoodAnalyserFactory.CreateMoodAnalyserUsingParametrisedConstructor("MoodAnalyserUnitTests.Moodanalyser","MoodAnalyser", message);
                expected.Equals(obj);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_CLASS_FOUND, exception.exceptionType);
            }
        }

        [Test]
        public void
            CreateMoodAnalyserUsingParametrisedConstructor_GivenInProperConstructorName_shouldReturnConstructorNotFound()
        {
            try
            {
                string message = "Today I am happy";
                object expected = new MoodAnalyser(message);
                object obj =
                    MoodAnalyserFactory.CreateMoodAnalyserUsingParametrisedConstructor("MoodAnalyserUnitTests.MoodAnalyser",
                        "Moodanalyser", message);
                expected.Equals(obj);
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_CONSTRUCTOR_FOUND, exception.exceptionType);
            }
        }
    }
}