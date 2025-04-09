using ConsoleGameProject.Command;
using ConsoleGameProject.Interface;

namespace ConsoleGameProject;

public class TermialHub : Room, IRecoverable, IScannable
{
    public string RecoverableModule => "move";
    public bool isRecovered { get; set; } = false;

    public Action OnScanned { get; set; } = () =>
    {
        Util.TerminalLog("주변에서 손상된 파일을 발견했습니다.", delay: 500);
        Util.TerminalLog("파일을 출력합니다..", delay: 1500);
        Console.WriteLine();
        Util.TerminalLine("파일 : '#T_HUB_GUIDE'",  delay: 200);
        Util.PrintLine("───────────────────────────────────────────────────", delay: 200);
        Util.PrintLine("L0C@Ti0N: T3RMIN@L_HUB", delay: 200);
        Util.PrintLine(" ▓ 여r기는 †erminal H#B...", delay: 200);
        Util.PrintLine(" ▓ 이-동-을 하려m면...  ", delay: 200);
        Util.PrintLine("   → m0ve [방향] 명령어를 ㅅㅏ용하십시오.", delay: 500);
        Util.PrintLine("※ 모듈 상태: ERR#C0RRU-PTED", delay: 200);
        Util.PrintLine(" > 복구방법:", delay: 200);
        Util.PrintLine("   reco▓er mod▓le <모듈명>", delay: 200);
        Console.WriteLine();
        Util.PrintLine("   예시: r3c0v#r m0du1e m0%e", delay: 200);
        Util.PrintLine("───────────────────────────────────────────────────", delay: 200);
    };
  


    public TermialHub()
    {
        Name = "Terminal Hub - 터미널 허브";
        Description = new[]
        {
            "중앙 시스템 허브에 접속되었습니다.",
            "이곳은 여러 경로가 연결되는 핵심 구역입니다.",
            "일부 경로에서 신호가 감지되고 있습니다.",
            "다른 곳으로 이동하려면 특정 명령어를 사용해야 합니다."
            
        };

        Connections["northeast"] = Define.RoomKey.LogControlRoom;
        Connections["east"] = Define.RoomKey.VirusZone;
        Connections["south"] = Define.RoomKey.RecoveryControlRoom;

    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        if (!GameManager.player.UsableCommand.Contains("scan"))
        {
            Util.TerminalLog("관리자 권한이 확인되었습니다.", ConsoleColor.Green);
            Util.TerminalLog("scan 명령어가 활성화되었습니다.", ConsoleColor.Green);
            Console.WriteLine();
        
            // GameManager.player.AddCommand(new ScanCommand());
            new ScanCommand().OnRecovered?.Invoke();
        }
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