using System;
using Mono.Options;

namespace FancyHackerTerminal
{
    internal class Program
    {   
        static void Print(string data, int min, int max)
        {
            foreach(char character in data.ToCharArray())
            {
                Random random = new Random();

                Thread.Sleep((int)random.NextInt64(min, max));

                Console.Write(character);
            }
        }

        static void Main(string[] args)
        {
            try 
            {
                Options options = new Options();

                var optionSet = new OptionSet {
                    { "textcolor=", $"Set the text color (default: {options.TextColor}).", 
                        v => options.TextColor = Enum.TryParse(v, true, out ConsoleColor TextColor) ? TextColor : throw new ArgumentException("Invalid text color.") },
                    { "backgroundcolor=", $"Set the background color (default: {options.BackgroundColor}).", 
                        v => options.BackgroundColor = Enum.TryParse(v, true, out ConsoleColor BackgroundColor) ? BackgroundColor : throw new ArgumentException("Invalid background color.") },
                    { "f|codefile=", "Path to a file containing code to display. If not provided, random code will be generated.", f => options.CodeFile = f },
                    { "min=", $"Set the minimum speed (default: {options.MinSpeed}).", (int min) => options.MinSpeed = min },
                    { "max=", $"Set the maximum speed (default: {options.MaxSpeed}).", (int max) => options.MaxSpeed = max },
                    { "lines=", "Set the number of the lines to be printed", (long lines) => options.MaxLines = lines },
                    { "h|help", "Show this message and exit.", h => options.Help = h != null }
                };

                // parse the options
                optionSet.Parse(args);

                // Validate the options after parsing
                options.Validate(); 

                // show help
                if (options.Help) 
                {
                    optionSet.WriteOptionDescriptions (Console.Out);
                    return;
                }

                // set the program based on the options
                Console.ForegroundColor = options.TextColor;
                if (options.BackgroundColor.HasValue)
                    Console.BackgroundColor = options.BackgroundColor.Value;

                iCodeText codeText = new RandomCodeText();
                if (!string.IsNullOrWhiteSpace(options.CodeFile))
                    codeText = new FileCodeText(options.CodeFile);

                int i = 0;
                while(!options.MaxLines.HasValue || options.MaxLines > i) {
                    i++;

                    string newLine = codeText.NextLine();

                    Print(newLine, options.MinSpeed, options.MaxSpeed);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Try 'FancyHackerTerminal --help' for more information.");

                return;
            }

        }
    }
}