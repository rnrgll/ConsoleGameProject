namespace ConsoleGameProject;

public abstract class Room
{
    //이름
    public string Name { get; protected set; }
    //설명
    public string[] Description { get; protected set; }
    //이동 가능한 방향
    public Dictionary<string, Define.RoomKey> Connections { get; protected set; } = new ();
    
    
    
    
    //방 입장시 발생하는 이벤트
    public virtual void OnEnter()
    {
        Util.PrintLine($"[{Name}] ", ConsoleColor.Black, ConsoleColor.Yellow,delay:500);
        foreach (var d in Description)
        {
            Util.TerminalLine(d, delay: 500);
        }

        Console.WriteLine();


    }

    public virtual void Input()
    {
        string input;
        do
        {
            input = Util.TerminalInput();
        }
        while (!GameManager.parser.ParseAndExecute(input));
    }
    public abstract void Update();
    public abstract void Result();
}