namespace ConsoleGameProject.Interface;

public interface ILoggable
{
    public List<string> LogMessages { get; protected set; }
    public List<string> PostLogMessages { get; protected set; }
    
}