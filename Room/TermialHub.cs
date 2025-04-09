namespace ConsoleGameProject;

public class TermialHub : Room, IRecoverableRoom
{
    public string RecoverableModule => "move";

    
    public TermialHub()
    {
        Name = "Terminal Hub - 터미널 허브";
        Description = "중앙 콘솔이 망가져 있습니다. 모듈이 복원되면 이동이 가능합니다.";
        
        Connections["northeast"] = "ErrorLogRoom";
        Connections["south"] = "VirusZone";
        
    }
    

    public override void Render()
    {
    }


    public override void Update()
    {
    }

    public override void Result()
    {
    }
}