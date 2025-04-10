using ConsoleGameProject.Interface;

namespace ConsoleGameProject.Command;

public class VaccineCommand : Command
{
    public static bool IsVaccineActive { get; private set; } = false;
    private ILoggable vaccineRoomLog = null;
    public VaccineCommand() : base("vaccine", Define.CommandHints.Vaccine)
    {
        
    }

    public override bool Execute(string[] args)
    {
        //args 1개
        //args = inactive/active 만 가능

        if (args.Length != 1)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }

        if (GameManager.roomManager.CurRoom is not VaccineCore vaccineCore)
        {
            Util.TerminalError("오류 : 현재 위치에서 백신 시스템을 제어할 수 없습니다.", "403_INVALID_MODULE_LOCATION");
            return false;
        }

        string option = args[0].ToLower();
        vaccineRoomLog = vaccineCore as ILoggable;

        if (option == "active")
        {
            if (IsVaccineActive)
            {
                Util.TerminalLog("백신 시스템이 이미 활성화된 상태입니다.");
            }
            else
            {
                IsVaccineActive = true;
                Util.PrintProgressBar("백신 시스템 활성화 중");
                Util.TerminalLog("백신 시스템이 정상적으로 작동을 시작했습니다.", ConsoleColor.Green, delay:600);
                Util.TerminalLog("바이러스에 대한 공격 프로토콜이 개방되었습니다", ConsoleColor.Green);
                

                //만약 플레이어의 사용 가능한 명령어에 attack이 없다면, attack을 활성화한다.

                if (!GameManager.player.UsableCommand.Contains("attack"))
                {
                    Util.TerminalLog("공격 권한을 확인했습니다.", ConsoleColor.Green,delay:600);
                    Util.TerminalLog("attack 명령어를 활성화합니다.", ConsoleColor.Green,delay:1000);
                    new AttackCommand().OnRecovered?.Invoke(); // attack 커맨드 활성화
                    Util.Print("", delay:600);
                }
            }
        }
        else if (option == "inactive")
        {
            if (IsVaccineActive)
            {
                IsVaccineActive = false;
                Util.PrintProgressBar("백신 시스템 비활성화 중");
                Util.TerminalLog("백신 시스템이 종료되었습니다.", ConsoleColor.Red,delay:600);
                Util.TerminalLog("공격 기능이 제한됩니다.", ConsoleColor.Red);
            }
            else
            {
                Util.TerminalLog("백신 시스템이 이미 비활성화된 상태입니다.");
            }
            
        }

        else
        {
            //잘못된 인자
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.", "400_UNEXPECTED_ARGUMENT");
            return false;
        }

        return true;


    }
}