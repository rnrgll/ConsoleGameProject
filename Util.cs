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
    
    public static void TerminalPrint(string message, ConsoleColor? textColor = null, int delay = 0)
    {
        Print("[GL!TCH_TERM] >> ", textColor==null? ConsoleColor.DarkGray:textColor);
        PrintLine(message, textColor, null, delay);
    }
    
    public static void TerminalError(string message, string errorCode = "UNKNOWN")
    {
        TerminalPrint(message, ConsoleColor.Red);
        PrintLine($"> ERROR_CODE_{errorCode}: {errorCode.Replace("_", " ")}", ConsoleColor.Red);
    }

    
    
    
    public static void WaitForAnyKey(string message = "[GL!TCH_TERM] >> 계속하려면 아무 키나 누르세요...", ConsoleColor? textColor = ConsoleColor.DarkGray)
    {
        PrintLine(message, textColor);

        while (Console.KeyAvailable)
            Console.ReadKey(true);

        Console.ReadKey(true);
    }

}