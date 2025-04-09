namespace ConsoleGameProject.Interface;

public interface IScannable
{
    public Action OnScanned { get; protected set; }
}