namespace ConsoleGameProject;

public class Title : Room
{
    private string nextRoomKey = "Intro";
    
    public Title()
    {
        Name = "시작 화면";
        Description = "시작 화면";
    }

    public override void OnEnter()
    {
        
    }

    public override void Render()
    {
        Console.Clear();

        // 로고
        Util.PrintLine("  ██████╗  ██╗      ██╗ ████████╗  ██████╗ ██╗  ██╗          ████████╗ ███████╗ ██████╗  ███╗   ███╗", ConsoleColor.Magenta,null, 200);
        Util.PrintLine(" ██╔════╝  ██║      ██║ ╚══██╔══╝ ██╔════╝ ██║  ██║          ╚══██╔══╝ ██╔════╝ ██╔══██╗ ████╗ ████║", ConsoleColor.Magenta, null, 200);
        Util.PrintLine(" ██║  ███║ ██║      ██║    ██║    ██║      ███████║             ██║    █████╗   ██████╔╝ ██╔████╔██║", ConsoleColor.Cyan , null, 200);
        Util.PrintLine(" ██║   ██║ ██║      ╚═╝    ██║    ██║      ██╔══██║             ██║    ██╔══╝   ██╔══██╗ ██║╚██╔╝██║", ConsoleColor.DarkCyan, null, 200);
        Util.PrintLine(" ╚██████╔╝ ███████╗ ██╗    ██║    ╚██████╗ ██║  ██║ ███████╗    ██║    ███████╗ ██║  ██║ ██║ ╚═╝ ██║", ConsoleColor.Yellow, null, 200);
        Util.PrintLine("  ╚═════╝  ╚══════╝ ╚═╝    ╚═╝     ╚═════╝ ╚═╝  ╚═╝ ╚══════╝    ╚═╝    ╚══════╝ ╚═╝  ╚═╝ ╚═╝     ╚═╝", ConsoleColor.DarkGray, null, 200);
        Console.WriteLine();

        Util.PrintLine("                             게임을 시작하려면 아무 키나 입력하세요.");

        Util.PrintLine("                                      개발자: 이도현");
        Util.PrintLine("                                      버전: v0.1.3 [DEMO]");
        Console.WriteLine();

    }

    public override void Input()
    {
        Console.CursorVisible = false;
        Console.ReadKey(true);
    }

    public override void Update()
    {
        
    }

    public override void Result()
    {
        GameManager.roomManager.MoveTo(nextRoomKey);
    }
}
