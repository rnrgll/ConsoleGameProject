namespace ConsoleGameProject;

public class Title : Room
{
    public Title()
    {
        Name = "시작 화면";
        Description = "깨진 터미널 화면.";

    }

    public override void Render()
    {
        Console.WriteLine("GL!TCH_TERM");
        Console.WriteLine("게임을 시작하려면 'start'를 입력하세요");
    }

    public override void Input()
    {
        Util.Print(">");
        while(!GameManager.parser.ParseAndExecute(Console.ReadLine()))
        {
            Util.Print(">");
        }
        
    }

    public override void Update()
    {
    }

    public override void Result()
    {
    }
}