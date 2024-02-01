using System.IO;
using System.Text;
using Mono.Options;

namespace FancyHackerTerminal;

public class FileCodeText : iCodeText
{
    int i;
    string[] fileText;

    public FileCodeText(string filePath) 
    {
        i = 0;
        fileText = File.ReadAllLines(filePath);
    }

    public string NextLine()
    {
        if (fileText == null)
            return string.Empty;

        i++;
        if (fileText.Length <= i)
            i = 0;

        StringBuilder line = new StringBuilder(fileText[i]);
        line.AppendLine();

        return line.ToString();
    }
}
