using System.Text;

namespace FancyHackerTerminal;

public class RandomCodeText : iCodeText
{
    // possible option to create 'actual' code to be printed
    // static string GenerateCode()
    // {
    //     Random rand = new Random();

    //     var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
    //         "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
    //         "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

    //     string[] codes = new[]{"if ({{NUM}} {{SIGN}} {{NAME}})", "while ({{NAME}})", "printf({{STRING}})"};

    //     int codeIndex = (int)rand.NextInt64(codes.Count());        
    // }


    public string NextLine()
    {
        var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
            "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
            "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

        Random rand = new Random();

        StringBuilder sentence = new StringBuilder();

        while (!(rand.NextInt64(0, 10) % 8 == 0)) {
            int wordIndex = (int) rand.NextInt64(words.Count());

            sentence.Append(words[wordIndex]).Append(" ");
        }

        sentence.AppendLine();

        return sentence.ToString();
    }
}
