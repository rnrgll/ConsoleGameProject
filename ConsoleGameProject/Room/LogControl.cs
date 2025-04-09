using ConsoleGameProject.Interface;

namespace ConsoleGameProject;

public class LogControl : Room, IRecoverable, IScannable, ILoggable
{
    
    public string RecoverableModule => "log";
    public bool isRecovered { get; set; } = false;

    public Action OnScanned { get; set; } = () =>
    {
        Util.TerminalLog("로그 시스템이 손상되어 있습니다.", delay: 500);
        Util.TerminalLog("모듈 손상으로 인해 모든 로그 접근이 차단되었습니다.", delay: 500);
        Util.TerminalLog("터미널에서 오류 데이터를 추출합니다...", delay: 1500);
        Console.WriteLine();
        //Util.TerminalLine("파일 : '#T_HUB_GUIDE'",  delay: 200);
        Util.PrintLine("─────────────────────TERMINAL──────────────────────", delay: 200);
        Util.PrintLine("## LOCATION: D14G-N0ST1CS_C0R3", delay: 200);
        Util.PrintLine("## TERMI#AL 'LOG-MODULE' ▓▒░ SIGNAL LOST ░▒▓", delay: 200);
        Util.PrintLine("## LINK_STATUS : ▓▒▒ DISCONNECTED ▒▒▓", delay: 200);
        Util.PrintLine("## RED_ALERT : SIG#AL OV#RL0AD", delay: 200);
        Util.PrintLine("## 로그 시스템 수동 복구가 필요합니다.", delay: 200);
        Util.PrintLine("## >> r3c0v#r modu1e l0g", delay: 200);
        Util.PrintLine("───────────────────────────────────────────────────", delay: 200);
    };

    public List<string> LogMessages { get; set; } = new()
    {
        "[LOG 02:01:11] LOG-MODULE status: Stable",
        "[LOG 02:14:52] External signal received",
        "[LOG 02:15:03] Anomalous packets detected — trace failed",
        "[LOG 02:15:50] Redirection initiated: ALL_LOG_STREAMS > /dev/null",
        "[LOG 02:16:00] LOG-MODULE status: CORRUPTED",
        "[LOG 02:16:10] Admin privileges lost",
        "[LOG 02:16:30] LOG access disabled"
    };

    public List<string> PostLogMessages { get; set; } = new()
    {
        "[LOG 04:00:00] LOG-MODULE successfully recovered",
        "[LOG 04:00:01] System memory stream reconnected — access to records granted",

    };


    //생성자
    public LogControl()
    {
        Name = "Log Control Room - 로그 제어실";
        Description = new[]
        {
            "로그 제어실에 접속되었습니다.",
            "본 구역은 전역 로그 시스템을 제어하는 핵심 구역입니다.",
        };
        Connections["southwest"] = "TerminalHub";
    }
 


    public override void Render()
    {
        
    }
    
    public override void Update()
    {
    }

    public override void Result()
    {
        
    }


    
}