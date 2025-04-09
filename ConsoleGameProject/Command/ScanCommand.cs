using ConsoleGameProject.Interface;

namespace ConsoleGameProject.Command;

public class ScanCommand : Command
{
    public ScanCommand() : base("scan", Define.CommandHints.Scan)
    {
    }

    public override bool Execute(string[] args)
    {
        if (GameManager.roomManager.CurRoom is not IScannable scannableRoom)
        {
            return false;
        }
        
        if (args.Length > 0)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }
        
        //현재 위치 정보와 이동 가능한 경로 출력
       Util.TerminalLog("현재 위치를 스캔합니다...", delay:1000);
       Console.WriteLine();
       
       Util.PrintLine("───────────────────────────────────────────────────", ConsoleColor.Cyan, delay: 200);
       Util.PrintLine("[현재 위치]",ConsoleColor.Cyan, delay:500);
       Util.PrintLine(GameManager.roomManager.CurRoom.Name,ConsoleColor.Cyan, delay:500);

       Console.WriteLine();
       Util.PrintLine("[이동 가능한 경로]",ConsoleColor.Cyan,  delay:500);
       foreach (var connection in GameManager.roomManager.CurRoom.Connections)
       {
           Room room = GameManager.roomManager.GetRoom(connection.Value);
           Util.PrintLine($"- {connection.Key} : {room.Name}",ConsoleColor.Cyan, delay:500);
       }
       Util.PrintLine("───────────────────────────────────────────────────", ConsoleColor.Cyan, delay: 200);


       Console.WriteLine();
       
       //스캔 정보 출력(모듈 복구 전 & 후)
       if (scannableRoom is IRecoverable recoverableRoom && recoverableRoom.isRecovered == false)
       {
           scannableRoom.OnScanned?.Invoke();
          
       }
       else
       {
           Util.TerminalLog("해당 구역의 시스템 모듈이 모두 복원되었습니다.", delay:500);
           Util.TerminalLog("추가로 스캔할 수 있는 정보가 없습니다.", delay:500);

       }
       Console.WriteLine();

       
       return true;
    }
}