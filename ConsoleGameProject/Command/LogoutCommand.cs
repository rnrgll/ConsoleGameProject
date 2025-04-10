namespace ConsoleGameProject.Command;

public class LogoutCommand : Command
{
    public LogoutCommand() : base("logout", Define.CommandHints.Logout)
    {
    }

    public override bool Execute(string[] args)
    {
        if (GameManager.roomManager.CurRoom is not Ending endingRoom)
        {
            return false;
        }

        endingRoom.IsLogout = true;
        return true;
    }

   
}