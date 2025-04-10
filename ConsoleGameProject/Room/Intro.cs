namespace ConsoleGameProject;

public class Intro : Room
{
    private string nextRoomKey = "TerminalHub";
    public Intro()
    {
        Name = "인트로";
        //Description = "설명";

    }
    
    public override void OnEnter()
    {
        Util.PrintProgressBar("시스템 부팅 중");
        Console.WriteLine();
        
        Util.TerminalLog($"시스템 초기화 중... [GL!TCH_TERM {Define.GameInfo.Version}]", ConsoleColor.Green, 600);
        
        Util.TerminalLog("사용자 세션 연결 요청 중......", ConsoleColor.Green, 2000);
        Util.TerminalLog("세션 ID: #UNKN0WN_USER", ConsoleColor.Green, 1500);
        Console.WriteLine();
        
        Util.TerminalLog("오류 : 사용자 식별 실패", ConsoleColor.Red, 1500);
        Util.TerminalLog("오류 : 데이터 무결성 검증 실패", ConsoleColor.Red, 1500);
        Util.TerminalLog("오류 : 주요 시스템 모듈 다수 손상 감지", ConsoleColor.Red, 2000);
        Console.WriteLine();

        Util.TerminalLine("현재 콘솔 시스템에 심각한 오류가 발생했습니다.", null, 800);
        Util.TerminalLine("핵심 시스템 모듈이 손상되어 명령어가 작동하지 않습니다.", null, 800);
        Util.TerminalLine("이로 인해 대부분의 기능이 마비된 상태입니다.", null, 1200);
        Util.TerminalLine("… 하지만 복구는 가능해 보입니다.", null, 800);
        Util.TerminalLine("손상된 모듈을 복구해 시스템을 정상 상태로 되돌려야 합니다.", null, 1200);
        Util.TerminalLine("관리자 권힌을 임시 부여합니다.", null, 1500);
        
        Console.WriteLine();

        Util.TerminalLog("관리자 권한 임시 승인됨", ConsoleColor.Red, 600);
        Util.TerminalLog("현재 사용 가능한 명령어: 'start'", ConsoleColor.Red, 600);
        Util.TerminalLine("'start' 명령어를 입력해 복구 프로세스를 시작하세요.",null, 800);

        
        //다시 보이도록 처리
        Console.CursorVisible = true;
    }
    
    

    public override void Update()
    {
    }

    public override void Result()
    {
    }
}