using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyserUnitTests
{
    public class MoodAnalyserFactory
    {    

        //This method creates object with default constructor
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match match = Regex.Match(className, pattern);

            if (match.Success)
            {
                try
                {  
                    Assembly assembly = Assembly.GetExecutingAssembly();
                  
                    Type moodAnalyserType = assembly.GetType(className);
                   
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException e)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_CLASS_FOUND,
                        "No such class is found");
                }
            }
            else
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_CONSTRUCTOR_FOUND,
                    "No constructor found");
        }

        //This method creates object with parameterised constructor
        public static object CreateMoodAnalyserUsingParametrisedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                try
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                        object instance = constructorInfo.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_CONSTRUCTOR_FOUND,
                            "No such constructor  found");
                    }
                }
                catch (ArgumentNullException e)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_CONSTRUCTOR_FOUND,
                        "No such constructor  found");
                }
            }
            else
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_CLASS_FOUND,
                    "No such class is  found");

        }
    }
}
