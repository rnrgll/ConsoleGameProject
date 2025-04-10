using ConsoleGameProject.Command;

namespace ConsoleGameProject;

public class Define
{
    public static Dictionary<string, Func<ICommand>> Commands = new()
    {
        { "start", () => new StartCommand() },
        { "move", () => new MoveCommand() },
        { "scan", () => new ScanCommand() },
        { "recover", () => new RecoverCommand() },
        { "log", () => new LogCommand() },
        {"logout", () => new LogoutCommand()},
        { "vaccine", () => new VaccineCommand() },
        { "attack", () => new AttackCommand() }
    };
    
    public static class CommandHints
    {
        public const string Start = "";
        public const string Recover = "";
        public const string Move = "move [방향] : 방향을 입력해 방을 이동할 수 있습니다. (예: move north)";
        public const string Scan = "scan : 현재 위치를 스캔해 구역 정보를 확인합니다.";
        public const string Log = "log : 시스템 로그를 조회합니다. 해당 구역에 로그 시스템이 있을 경우에만 사용 가능합니다.";
        public const string Vaccine = "vaccine [active/inactive] : 백신 시스템을 제어합니다. active로 설정하면 attack 명령어가 활성화됩니다. '백신 코어'에서만 사용 가능합니다.";

        public const string Attack = "attack : 감염된 시스템 객체를 제거합니다. 감염 구역에서만 사용 가능하며, 백신 시스템이 활성화된 상태여야 합니다.";
        public const string Logout = "logout : 콘솔 세션을 종료할 수 있습니다.";
    }
    
    public enum RoomKey
    {
        Title,
        Intro,
        Ending,
        TerminalHub,
        LogControlRoom,
        SystemCore,
        VaccineCore
        
    }

    public static string[] AttackCode =
    {
        "VX_NULL",
        "N3T-LOCK"
    };


    public static class GameInfo
    {
        public const string Developer = "이도현";
        public const string Version = "v0.1.3";
    }

}