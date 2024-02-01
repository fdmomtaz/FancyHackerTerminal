namespace FancyHackerTerminal 
{
    public class Options
    {
        public ConsoleColor TextColor { get; set; } = ConsoleColor.DarkGreen;
        public ConsoleColor? BackgroundColor { get; set; }

        public string? CodeFile { get; set; }

        public int MinSpeed { get; set; } = 10;
        public int MaxSpeed { get; set; } = 120;

        public long? MaxLines { get; set; }

        public bool Help { get; set; }

        public void Validate()
        {
            // Validate MinSpeed and MaxSpeed
            if (MinSpeed < 0 || MaxSpeed < 0) {
                throw new ArgumentException("Speed values cannot be negative.");
            }

            if (MinSpeed > MaxSpeed) {
                throw new ArgumentException("Minimum speed cannot be greater than maximum speed.");
            }

            if (MaxLines.HasValue && MaxLines < 0)  {
                throw new ArgumentException("maximum number of lines to be printed cannot be negative.");
            }

            // Validate TextColor and BackgroundColor
            if (!Enum.IsDefined(typeof(ConsoleColor), TextColor)) {
                throw new ArgumentException($"Invalid text color: {TextColor}.");
            }

            if (BackgroundColor.HasValue && !Enum.IsDefined(typeof(ConsoleColor), BackgroundColor)) {
                throw new ArgumentException($"Invalid background color: {BackgroundColor}.");
            }

            if (!string.IsNullOrWhiteSpace(CodeFile) && !File.Exists(CodeFile)) {
                throw new ArgumentException($"The code file doesn't exist: {CodeFile}");
            }
        }
    }
}