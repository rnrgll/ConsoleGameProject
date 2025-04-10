using ConsoleGameProject.Interface;

namespace ConsoleGameProject;

public class SystemCore : Room, IScannable, ILoggable
{
    public Action OnScanned { get; set; } = () =>
    {
        Util.TerminalLog("모듈 전반에 바이러스 감염이 확인되며, 주요 기능이 정지된 상태입니다.", delay: 500);
        Util.TerminalLog("정화를 위해 백신 시스템을 활성화하고, 감염 소스를 제거해야 합니다.", delay: 500);
        Util.TerminalLog("감염 경로 및 상태를 파악하기 위해 시스템 로그 조회가 필요합니다.", delay: 500);
        Util.TerminalLog("인근 단말기에서 관련 시스템 로그를 확인할 수 있을 것으로 보입니다.", delay: 500);
        Util.TerminalLog("단말기 스캔중...", delay: 1500);
        Console.WriteLine();
        if (GameManager.player.UsableCommand.Contains("log"))
        {
            Util.TerminalLog("시스템 로그 접근 가능", delay:500);
            Util.TerminalLog("시스템 코어의 상태 및 작동 기록을 확인할 수 있습니다..", delay: 500);
            

        }
        else
        {
            
            Util.TerminalLog("시스템 로그 접근이 차단되어 있습니다.", delay: 500);
            Util.TerminalLog("LOG-MODULE 상태: 손상됨", delay: 500);
            Util.TerminalLog("로그 조회 불가능 — 로그 시스템 복구 필요", delay: 500);


        }
      
    };

    public List<string> LogMessages { get; set; } = new()
    {
        "[LOG 02:30:00] System Core accessed",
        "[LOG 02:30:05] Unauthorized data packets detected",
        $"[LOG 02:30:15] Malware signature: {Define.AttackCode[0]}",
        "[LOG 02:30:25] Quarantine failed — infection adapting",
        $"[LOG 02:30:35] Emergency containment password initialized: {Define.AttackCode[1]}",
        "[LOG 02:30:45] Attempting full shutdown...",
        "[LOG 02:30:50] Shutdown aborted — access level insufficient",
        "[LOG 02:30:55] Manual countermeasure required",

    };
    
    public List<string> PostLogMessages { get; set; } = new()
    {
        "[LOG 04:30:00] Virus signature eliminated from core",
        "[LOG 04:30:02] Core integrity: RESTORED",
        "[LOG 04:30:05] All modules online. System state: STABLE"
    };

    
    public SystemCore()
    {
        Name = "System Core - 시스템 코어";
        Description = new[]
        {
            "시스템 코어 구역에 도달했습니다.",
            "본 구역은 GL!TCH_TERM의 중앙 제어 모듈이 위치한 장소입니다.",
        };

        Connections["north"] = Define.RoomKey.LogControlRoom;
        Connections["west"] = Define.RoomKey.TerminalHub;

    }
    
    public override void Update()
    {
    }

    public override void Result()
    {
    }
}