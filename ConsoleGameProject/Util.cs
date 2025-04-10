namespace ConsoleGameProject;

public class Util
{
    // private ConsoleColor defaultFg = Console.ForegroundColor;
    // private ConsoleColor defaultBg = Console.BackgroundColor;
    
    public static void PrintLine(string context, ConsoleColor? textColor = null, ConsoleColor? backgroundColor = null, int delay = 0)
    {
        SetConsoleColor(textColor,backgroundColor);
        Console.WriteLine(context);
        
        Thread.Sleep(delay);
        ResetColor();
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
    
    private static void SetConsoleColor(ConsoleColor? fg, ConsoleColor? bg)
    {
        if (fg.HasValue)
            Console.ForegroundColor = fg.Value;
        if (bg.HasValue)
            Console.BackgroundColor = bg.Value;
    }

    private static void ResetColor() => Console.ResetColor();

    
    public static void TerminalLine(string message, ConsoleColor? textColor = null, int delay = 0)
    {
        Print("> ", textColor);
        PrintLine(message, textColor, null, delay:delay);
    }

    
    public static void TerminalLog(string message, ConsoleColor? textColor = null, int delay = 0)
    {
        Print("[GL!TCH_TERM] >> ", textColor==null? null:textColor);
        PrintLine(message, textColor, null, delay);
    }
    
    public static void TerminalError(string message, string errorCode = "UNKNOWN")
    {
        TerminalLog(message, ConsoleColor.Red);
        TerminalLine($"ERROR_CODE_{errorCode}: {errorCode.Replace("_", " ")}", ConsoleColor.Red);
        Console.WriteLine();
    }


    public static string TerminalInput(string prompt = "> ")
    {
        Print(prompt);
        return Console.ReadLine();
    }
    
    
    public static void WaitForAnyKey(string message = "[GL!TCH_TERM] >> 계속하려면 아무 키나 누르세요...", ConsoleColor? textColor = null)
    {
        PrintLine(message, textColor);

        while (Console.KeyAvailable)
            Console.ReadKey(true);

        Console.ReadKey(true);
    }


    public static void PrintProgressBar(string message)
    {
        Util.Print($"{message} [",ConsoleColor.Green);
        for (int i = 0; i <= 20; i++)
        {
            Util.Print("■", ConsoleColor.Green, delay:50);
        }
        Util.PrintLine("] 완료",ConsoleColor.Green, delay:500);
    }

}