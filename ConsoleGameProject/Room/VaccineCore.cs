using System.Drawing;
using ConsoleGameProject.Interface;

namespace ConsoleGameProject;

public class VaccineCore : Room, IRecoverable, IScannable, ILoggable
{
    public string RecoverableModule => "vaccine";
    public bool isRecovered { get; set; } = false;
    private string lastLogTime = "LOG 04:12:05";


    public Action OnScanned { get; set; } = () =>
    {
  
        Util.TerminalLog("백신 시스템이 현재 비정상적으로 작동 중입니다.", delay: 500);
        Util.TerminalLog("인근 단말기에서 관련 시스템 로그를 확인할 수 있을 것으로 보입니다.", delay: 500);
        Util.TerminalLog("단말기 스캔중...", delay: 1500);
        Console.WriteLine();
        if (GameManager.player.UsableCommand.Contains("log"))
        {
            Util.TerminalLog("시스템 로그 접근 가능", delay:500);
            Util.TerminalLog("백신 시스템 상태 및 작동 기록을 확인할 수 있습니다.", delay:500);
            

        }
        else
        {
            
            Util.TerminalLog("시스템 로그 접근이 차단되어 있습니다.",ConsoleColor.Red, delay: 500);
            Util.TerminalLog("LOG-MODULE 상태: 손상됨",ConsoleColor.Red, delay: 500);
            Util.TerminalLog("로그 조회 불가능 — 로그 시스템 복구 필요",ConsoleColor.Red, delay: 500);


        }
      
    };

    public List<string> LogMessages { get; set; } = new()
    {
        "[LOG 02:17:15] Attempted: VaccineEngine.Run()",
        "[LOG 02:17:16] Access denied — Module dependency missing",
        "[LOG 02:17:17] Required: log_module, integrity_module",
        "[LOG 02:18:00] SYSTEM RESPONSE: Retrying in safe mode...",
        "[LOG 02:18:05] CRITICAL ERROR: Isolation failed. Infection spreading.",
        "[LOG 02:18:10] Hint: Manual recovery of module is required",


    };
    
    public List<string> PostLogMessages { get; set; } = new()
    {
        "[LOG 04:12:03] VaccineEngine initialized successfully",
        "[LOG 04:12:05] Manual control enabled — Use 'vaccine' command to operate",
    };

    public VaccineCore()
    {
        Name = "Vaccine Core - 백신 코어";
        Description = new[]
        {
            "백신 코어에 접속되었습니다.",
            "시스템 내부의 정화 모듈이 설치된 코어 구역입니다.",
            "바이러스 침입을 막기 위한 백신 시스템이 배치되어 있습니다."
        };

        Connections["north"] = Define.RoomKey.TerminalHub;
    }


    public void AddLogMessage()
    {
        
    }


    public override void Update()
    {
    }

    public override void Result()
    {
    }
}