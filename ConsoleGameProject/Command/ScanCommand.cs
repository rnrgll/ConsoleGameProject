namespace ConsoleGameProject.Command;

public class ScanCommand : Command, ICommand
{
    public ScanCommand() : base("scan", Define.CommandHints.Scan)
    {
    }

    public bool Execute(string[] args)
    {
        if (GameManager.roomManager.CurRoom is Intro)
        {
            return false;
        }
        if (args.Length > 0)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }
        
       Util.TerminalLog("현재 위치를 스캔합니다...", delay:1000);
       Console.WriteLine();
       Util.PrintLine("[현재 위치]",delay:500);
       Util.PrintLine(GameManager.roomManager.CurRoom.Name,delay:500);
       Console.WriteLine();
       Util.PrintLine("[이동 가능한 경로]", delay:500);
       foreach (var connection in GameManager.roomManager.CurRoom.Connections)
       {
           Room room = GameManager.roomManager.GetRoom(connection.Value);
           Util.PrintLine($"- {connection.Key} : {room.Name}", delay:500);
       }

       Console.WriteLine();

       return true;
    }
}