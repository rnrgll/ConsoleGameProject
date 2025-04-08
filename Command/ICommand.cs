namespace ConsoleGameProject.Command;

public interface ICommand
{
    public bool Execute(string[] args);
}