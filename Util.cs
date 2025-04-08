namespace ConsoleGameProject;

public class Util
{
    // private ConsoleColor defaultFg = Console.ForegroundColor;
    // private ConsoleColor defaultBg = Console.BackgroundColor;
    
    public static void PrintLine(string context, ConsoleColor? textColor = null, ConsoleColor? backgroundColor = null, int delay = 0)
    {
        if (textColor.HasValue)
            Console.ForegroundColor = textColor.Value;

        if (backgroundColor.HasValue)
            Console.BackgroundColor = backgroundColor.Value;
        Console.WriteLine(context);
        
        Thread.Sleep(delay);
        Console.ResetColor();
    }
    
    public static void Print(string context, ConsoleColor? textColor = null, ConsoleColor? backgroundColor = null, int delay = 0)
    {
        if (textColor.HasValue)
            Console.ForegroundColor = textColor.Value;

        if (backgroundColor.HasValue)
            Console.BackgroundColor = backgroundColor.Value;
        Console.Write(context);
        
        Thread.Sleep(delay);
        Console.ResetColor();
    }
}