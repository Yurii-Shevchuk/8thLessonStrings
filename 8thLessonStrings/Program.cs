using System;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string[] stringsForComparison = { "  hello, world", "Hello, world", "Hello, world     ", "hello, world" };
        bool trimStrings = true;
        string stringsAreTrimmed = trimStrings ? "(strings are trimmed so spaces at both ends don't count)" : "";

        for (int i = 0; i < stringsForComparison.Length; i++)
        {
            foreach(var s in stringsForComparison)
            {
                bool comparisonResult = Compare(stringsForComparison[i], s, trimStrings);
                Console.WriteLine($"Result of comparison of the \"{stringsForComparison[i]}\" and \"{s}\" is {comparisonResult} {stringsAreTrimmed} \n");
            }
        }
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        string stringForAnalysis = " 12345abc ABC$#@"; //все, окрім літер та цифр воно рахує за спец. символ
        var analysisResult = Analyze(stringForAnalysis);
        Console.WriteLine($"The number of letters in {stringForAnalysis} is {analysisResult.alphabeticChars}");
        Console.WriteLine($"The number of digits in {stringForAnalysis} is {analysisResult.digitChars}");
        Console.WriteLine($"The number of special characters in {stringForAnalysis} is {analysisResult.specialChars}");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        string stringForSorting = "Hello, World!";
        Console.WriteLine($"String before sorting -> {stringForSorting}");
        Console.Write("String after sorting -> ");
        Console.WriteLine(Sort(stringForSorting));
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        Console.Write("All the duplicated characters in \"Hello, and hii, my name is Tom, the Trickster\" are: ");
        Console.WriteLine(Duplicate("Hello, and hii, my nam is Tom, the Trickster"));
    }
    static bool Compare(string s1, string s2, bool TrimStrings)
    {
        if(TrimStrings)
        {
        s1 = s1.Trim();
        s2 = s2.Trim();
        }

        // Чи є сенс порівнювати стрічки посимвольно, якщо варіант нижче працює? 

        if(s1 == s2) return true;
        return false;
    }

    static (int alphabeticChars, int digitChars, int specialChars) Analyze(string s)
    {
        int alphabeticChars= 0, digitChars= 0, specialChars= 0;
        foreach(char c in s)
        {
            if(char.IsLetter(c))
            {
                alphabeticChars++;
            }
            else if(char.IsDigit(c))
            {
                digitChars++;
            }
            else
            {
                specialChars++;
            }
        }
        return (alphabeticChars, digitChars, specialChars);
    }

    static string Sort(string s)
    {
        s = s.ToLower();
        char[] stringToArray = s.ToCharArray();
        Array.Sort(stringToArray);
        s = new string(stringToArray);
        return s;
    }
    static char[] Duplicate(string s)
    {
        s= s.ToLower();
        StringBuilder duplicatedChars = new StringBuilder();
        StringBuilder inputString = new StringBuilder(s);
        for(int i = 0; i<inputString.Length; i++)
        {
            char c = inputString[i];
            inputString.Remove(i, 1);
            if(inputString.ToString().Contains(c) && !(char.IsWhiteSpace(c)))
            {
                duplicatedChars.Append(c);
                inputString.Replace(c, ' ');
            }
        }
 
        return duplicatedChars.ToString().ToCharArray();
    }

}