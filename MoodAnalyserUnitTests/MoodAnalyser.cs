using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserUnitTests
{
    public class MoodAnalyser
    {
        private string sentence;
        public MoodAnalyser()
        {

        }

        public MoodAnalyser(string input)
        {
            this.sentence = input;
        }


        public string AnalysisMoodWithDefaultConstructor(string sentence)
        {
            return sentence.ToLower().Contains("sad") ? "SAD" : "HAPPY";
        }
        public string AnalysisMoodWithParameterisedConstructor()
        {

            return sentence.ToLower().Contains("sad") ? "SAD" : "HAPPY";
        }


    }
}
