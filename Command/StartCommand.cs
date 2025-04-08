namespace ConsoleGameProject.Command;

public class StartCommand : ICommand
{
    public bool Execute(string[] args)
    {
        if (args.Length > 0)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }
        if (GameManager.roomManager.CurRoom is not Title)
        {
            return false;
        }

        

        GameManager.roomManager.MoveTo("TerminalHub");
        return true;
    }
}