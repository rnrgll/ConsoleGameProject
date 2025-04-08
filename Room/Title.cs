namespace ConsoleGameProject;

public class Title : Room
{
    public Title()
    {
        Name = "시작 화면";
        Description = "깨진 터미널 화면. 시스템 복원을 시도하려면 아무 키나 누르십시오.";

        Connections["start"] = "TerminalHub";
    }

    public override void Render()
    {
        OnEnter();
    }

    public override void Input()
    {
        
    }

    public override void Update()
    {
    }

    public override void Result()
    {
    }
}