using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserUnitTests
{
    
        public class MoodAnalyserNull : Exception
        {
            public string IsHappy;
            public MoodAnalyserNull(string IsMood)
            {
                IsHappy = IsMood;
            }
        }
    
}
