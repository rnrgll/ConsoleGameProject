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
        //{ "shop", () => new ShopCommand() },
        //{ "attack", () => new AttackCommand() }
    };
    
    public static class CommandHints
    {
        public const string Start = "";
        public const string Recover = "";
        public const string Move = "move [방향] : 방향을 입력해 방을 이동할 수 있습니다. (예: move north)";
        public const string Scan = "scan : 현재 위치를 스캔해 구역 정보를 확인합니다.";
        public const string Log = "log : 시스템 로그를 조회합니다. 해당 구역에 로그 시스템이 있을 경우에만 사용 가능합니다.";
        public const string Vaccine = "";
        public const string Attack = "attack 명령어로 전투를 시작할 수 있습니다. 적을 쓰러뜨리세요!";
        public const string Logout = "logout : 콘솔 세션을 종료할 수 있습니다.";
    }
    
    public enum RoomKey
    {
        Title,
        Intro,
        Ending,
        TerminalHub,
        LogControlRoom,
        VirusZone,
        RecoveryControlRoom
        
    }
    
    
    
    public static class Theme
    {
        public static readonly ConsoleColor SystemTag = ConsoleColor.DarkGray;
        public static readonly ConsoleColor Info = ConsoleColor.Cyan;
        public static readonly ConsoleColor Warning = ConsoleColor.Yellow;
        public static readonly ConsoleColor Error = ConsoleColor.Red;
        public static readonly ConsoleColor Prompt = ConsoleColor.Green;
    }


    public static class GameInfo
    {
        public const string Developer = "이도현";
        public const string Version = "v0.1.3";
    }

}