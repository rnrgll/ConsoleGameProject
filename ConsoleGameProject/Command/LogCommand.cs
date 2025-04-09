using ConsoleGameProject.Interface;

namespace ConsoleGameProject.Command;

public class LogCommand : Command
{
    public LogCommand() : base("log", Define.CommandHints.Log) { }

    public override bool Execute(string[] args)
    {
        // - 인자 체크 : 인자 없어야 함 (완)
        // - Iloggable 인지 체크 (완)
        // - 로그 정보 출력 (완)
        // - 복구되었을 때 로그를 추가할 것인가....

        if (args.Length > 0)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }
        

        if (GameManager.roomManager.CurRoom is not ILoggable loggableRoom)
        {
            Util.TerminalLog("로그 시스템이 존재하지 않는 구역입니다.", ConsoleColor.Red);
            return true;
        }
        
        
        Util.TerminalLog("시스템 로그를 조회합니다...", delay:1000);
        Console.WriteLine();
        
        Util.PrintLine("─────────────────────System Log────────────────────", ConsoleColor.Magenta, delay: 200);
        foreach (var log in loggableRoom.LogMessages)
        {
            Util.PrintLine(log,ConsoleColor.Magenta, delay:200);
        }
        Util.PrintLine("───────────────────────────────────────────────────", ConsoleColor.Magenta, delay: 200);

        Console.WriteLine();

        return true;
    }
}