namespace ConsoleGameProject;

public class Title : Room
{
    //private string nextRoomKey = "Intro";
    private Define.RoomKey nextRoomKey = Define.RoomKey.Ending; //최종에서는 Intro로 돌려놓기
    
    public Title()
    {
        Name = "시작 화면";
        //Description = "시작 화면";
    }

    public override void OnEnter()
    {
        Console.CursorVisible = false;
    }

    public override void Render()
    {
        Console.Clear();

        // 로고
        Util.PrintLine("  ██████╗  ██╗      ██╗ ████████╗  ██████╗ ██╗  ██╗          ████████╗ ███████╗ ██████╗  ███╗   ███╗", ConsoleColor.Magenta,null, 100);
        Util.PrintLine(" ██╔════╝  ██║      ██║ ╚══██╔══╝ ██╔════╝ ██║  ██║          ╚══██╔══╝ ██╔════╝ ██╔══██╗ ████╗ ████║", ConsoleColor.Magenta, null, 100);
        Util.PrintLine(" ██║  ███║ ██║      ██║    ██║    ██║      ███████║             ██║    █████╗   ██████╔╝ ██╔████╔██║", ConsoleColor.Cyan , null, 100);
        Util.PrintLine(" ██║   ██║ ██║      ╚═╝    ██║    ██║      ██╔══██║             ██║    ██╔══╝   ██╔══██╗ ██║╚██╔╝██║", ConsoleColor.DarkCyan, null, 100);
        Util.PrintLine(" ╚██████╔╝ ███████╗ ██╗    ██║    ╚██████╗ ██║  ██║ ███████╗    ██║    ███████╗ ██║  ██║ ██║ ╚═╝ ██║", ConsoleColor.Yellow, null, 100);
        Util.PrintLine("  ╚═════╝  ╚══════╝ ╚═╝    ╚═╝     ╚═════╝ ╚═╝  ╚═╝ ╚══════╝    ╚═╝    ╚══════╝ ╚═╝  ╚═╝ ╚═╝     ╚═╝", ConsoleColor.DarkGray, null, 300);
        Console.WriteLine();

        Util.PrintLine("                             게임을 시작하려면 아무 키나 입력하세요.");

        Util.PrintLine($"                                      개발자: {Define.GameInfo.Developer}");
        Util.PrintLine($"                                    버전: {Define.GameInfo.Version} [DEMO]");
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
        Console.CursorVisible = true;
    }
}
