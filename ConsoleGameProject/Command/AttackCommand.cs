namespace ConsoleGameProject.Command;

public class AttackCommand : Command
{
    public AttackCommand() : base("attack", Define.CommandHints.Attack)
    {
    }

    public override bool Execute(string[] args)
    {
        //인자가 0개여야 함
        //vaccine이 활성화되어 있으면 공격 가능
        if (args.Length > 0)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }

        if (GameManager.player.UsableCommand.Contains("vaccine") && VaccineCommand.IsVaccineActive)
        {
            if (GameManager.roomManager.CurRoom is SystemCore)
            {
                bool isSuccess = OnAttack();
                if (!isSuccess)
                {
                    return false;
                }
                
                return true;
            }
            else
            {
                //공격 대상이 없다는 오류 문구
                Util.TerminalError("오류 : 공격 대상을 찾을 수 없습니다.", "403_NO_TARGET");
                return false;
            }
            
        }
        
        
        //백신이 비활성화 상태여서 공격 명령어 사용이 불가능하다는 오류 문구
        Util.TerminalLog("백신 시스템이 비활성화 상태입니다.", ConsoleColor.Red,600);
        Util.TerminalLog("공격 기능을 사용할 수 없습니다.", ConsoleColor.Red,600);
        Util.TerminalLine("vaccine active 명령어로 백신 시스템을 먼저 가동하세요.",ConsoleColor.Red);
        return false;

    }


    private bool OnAttack()
    {
        string input;
        Util.TerminalLog("백신 시스템 활성화 상태 확인됨.", delay: 800);
        Util.TerminalLog("정화 프로토콜을 시작합니다...", delay: 1200);
        Util.TerminalLog("감염 소스 탐지 중...", delay: 1500);
        Util.TerminalLog("바이러스 시그니처 분석 시작: VX_███", ConsoleColor.Cyan, delay: 1500);

        
        Util.TerminalLine("▼ 감염된 바이러스의 시그니처를 입력하세요.", ConsoleColor.Cyan);
        input = Util.TerminalInput().Trim().ToUpper();

        if (input != Define.AttackCode[0])
        {
            Util.TerminalError("오류 : 시그니처 불일치. 정화 실패.", "401_INVALID_SIGNATURE");
            return false;
        }
        
        Util.TerminalLog("바이러스 시그니처 일치.", ConsoleColor.Green, delay: 500);
        Util.PrintProgressBar("격리 절차 진행 중");
        
        Util.TerminalLog("긴급 대응 비밀번호 입력 필요: _ _ _ - _ _ _ _", ConsoleColor.Cyan, delay: 600);
        Util.TerminalLine("▼ 비밀번호를 입력하세요.", ConsoleColor.Cyan);
        input = Util.TerminalInput().Trim().ToUpper();

        if (input != Define.AttackCode[1])
        {
            Util.TerminalError("오류 : 접근 거부. 비밀번호 인증 실패", "403_AUTH_FAILED");
            return false;
        }
        
        Util.TerminalLog("비밀번호 인증 완료. 긴급 정화 절차를 시작합니다...", ConsoleColor.Green, delay: 500);
        Util.PrintProgressBar("VX_NULL 제거 중");
        Util.Print("", delay:1000);
        Util.TerminalLog("감염 제거 완료", ConsoleColor.Green, 1000);
        Util.TerminalLog("감염 코드 정리 및 시스템 정합성 회복 진행 중...", ConsoleColor.Green, delay: 1000);
        Util.TerminalLog("시스템 안정성 복구 중...", ConsoleColor.Green, 1000);
        Util.Print("", delay:2500);
        GameManager.roomManager.MoveTo(Define.RoomKey.Ending);
        return true;

    }
}