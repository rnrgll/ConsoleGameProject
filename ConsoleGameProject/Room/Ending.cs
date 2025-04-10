using ConsoleGameProject.Command;

namespace ConsoleGameProject;

public class Ending : Room
{
    private bool isLogout;

    public bool IsLogout
    {
        get => isLogout;
        set
        {
            if (value == true)
            {
                isLogout = value;
                OnLogout();
            }
        }
    }
    
    public Ending()
    {
        Name = "엔딩";
        isLogout = false;
    }

    public override void OnEnter()
    {
        Util.TerminalLog("모든 시스템 모듈 상태: STABLE", ConsoleColor.Green, 600);
        Util.TerminalLog("시스템 복구 프로세스가 완료되었습니다.", ConsoleColor.Green, 800);
        Util.TerminalLog("시스템을 재가동합니다...", delay:1500);

        Console.WriteLine();
        Util.PrintProgressBar("시스템 재시작 중");
        Util.PrintLine("", delay:1200);
        
        Console.Clear();
        
        Util.PrintProgressBar("시스템 부팅 중");
        Console.WriteLine();
        Util.TerminalLog($"시스템 초기화 중... [GL!TCH_TERM {Define.GameInfo.Version}]", ConsoleColor.Green, 600);
        Util.TerminalLog("사용자 세션 연결 요청 중......", ConsoleColor.Green, 2000);
        Util.TerminalLog("세션 ID: D0H_YUN_01", ConsoleColor.Green, 1500);
        Util.TerminalLog("사용자 인증: 정상", ConsoleColor.Green, 1500);
        Util.TerminalLog("데이터 무결성: OK", ConsoleColor.Green, 1500);
        Util.TerminalLog("모듈 상태: 100% ONLINE", ConsoleColor.Green, 2000);
        Util.TerminalLog("GL!TCH_TERM 복구 완료", ConsoleColor.Green,delay:600);
        Util.TerminalLog("복구 시스템 종료 중...", ConsoleColor.Green,delay:1500);
        Util.TerminalLog("logout 명렁어를 활성화합니다",ConsoleColor.Green, delay:1000);
        new LogoutCommand().OnRecovered?.Invoke();
        Util.Print("", delay:1200);
        
        Util.TerminalLine("GL!TCH_TERM이 정상 상태로 복구되었습니다.", delay : 1000);
        Util.TerminalLine("시스템 종료를 위해 'logout' 명령어를 입력하세요.", delay : 100);
        
    }

    public override void Update()
    {
        
    }

    public override void Result()
    {
        
    }

    private void OnLogout()
    {
        Console.CursorVisible = false;
        Console.WriteLine();
        Util.TerminalLog("사용자 로그아웃 요청 수신됨...", ConsoleColor.Green, 1000);
        Util.TerminalLog("세션 종료 중...", ConsoleColor.Green, 1500);
        Util.TerminalLog("모든 연결 해제됨", ConsoleColor.Green, 1500);
        Util.TerminalLog("GL!TCH_TERM에서 안전하게 로그아웃되었습니다.", ConsoleColor.Green, 2500);
        
        Console.Clear();
        
        Util.PrintLine("████████╗ ██╗  ██╗  █████╗  ███╗   ██╗ ██╗  ██╗  ██████╗", ConsoleColor.Magenta, null, 100);
        Util.PrintLine("╚══██╔══╝ ██║  ██║ ██╔══██╗ ████╗  ██║ ██║ ██╔╝ ██╔════╝", ConsoleColor.Magenta, null, 100);
        Util.PrintLine("   ██║    ███████║ ███████║ ██╔██╗ ██║ █████╔╝  ╚█████╗ ", ConsoleColor.Cyan, null, 100);
        Util.PrintLine("   ██║    ██╔══██║ ██╔══██║ ██║╚██╗██║ ██╔═██╗   ╚═══██╗", ConsoleColor.DarkCyan, null, 100);
        Util.PrintLine("   ██║    ██║  ██║ ██║  ██║ ██║ ╚████║ ██║  ██╗ ██████╔╝", ConsoleColor.Yellow, null, 100);
        Util.PrintLine("   ╚═╝    ╚═╝  ╚═╝ ╚═╝  ╚═╝ ╚═╝  ╚═══╝ ╚═╝  ╚═╝ ╚═════╝ ", ConsoleColor.DarkGray, null, 300);

        
        
        Util.Print("            게임을 플레이해주셔서 감사합니다!");
        Util.WaitForAnyKey("             종료하려면 아무 키나 누르세요...");
        Environment.Exit(0);
    }
}