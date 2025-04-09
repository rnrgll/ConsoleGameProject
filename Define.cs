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
        //{ "log", () => new LogCommand() },
        //{ "shop", () => new ShopCommand() },
        //{ "attack", () => new AttackCommand() }
    };
    
    public static class CommandHints
    {
        public const string Start = "";
        public const string Move = "방향을 입력해 방을 이동할 수 있습니다. (예: move north)";
        public const string Log = "log 명령어를 입력해 시스템 로그를 열람할 수 있습니다.";
        public const string Scan = "scan 명령어로 현재 방의 정보와 연결된 경로를 확인할 수 있습니다.";
        public const string Shop = "buy 명령어로 아이템을 구매할 수 있습니다. key_item이 필요합니다.";
        public const string Attack = "attack 명령어로 전투를 시작할 수 있습니다. 적을 쓰러뜨리세요!";
        public const string Recover = "";
        public const string Logout = "";
    }
    
    
    
    
    public static class Theme
    {
        public static readonly ConsoleColor SystemTag = ConsoleColor.DarkGray;
        public static readonly ConsoleColor Info = ConsoleColor.Cyan;
        public static readonly ConsoleColor Warning = ConsoleColor.Yellow;
        public static readonly ConsoleColor Error = ConsoleColor.Red;
        public static readonly ConsoleColor Prompt = ConsoleColor.Green;
    }

}