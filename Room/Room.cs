namespace ConsoleGameProject;

public abstract class Room
{
    //이름
    public string Name { get; protected set; }
    //설명
    public string Description { get; protected set; }
    //이동 가능한 방향
    public Dictionary<string, string> Connections { get; protected set; } = new Dictionary<string, string>();
    
    
    
    //방 입장시 발생하는 이벤트
    public virtual void OnEnter()
    {
        Util.PrintLine($"[{Name}] ", delay:500);
        Util.PrintLine(Description, delay: 500);


    }
    
    public abstract void Render();

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