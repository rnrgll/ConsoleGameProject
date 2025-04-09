namespace ConsoleGameProject;

public class ErrorLogRoom : Room, IRecoverableRoom
{
    
    public string RecoverableModule => "log";
    public bool isRecoverd { get; set; }
    public Action RecoverHint { get; set; }

    public ErrorLogRoom()
    {
        Name = "Error Log Room - 에러 로그 룸";
        //Description = "붉은 에러 로그가 스코롤됩니다. 무언인가 남긴 흔적이 있습니다.";
        Connections["southwest"] = "TerminalHub";
        Connections["southeast"] = "DataCacheRoom";

    }
    
  


    public override void Render()
    {
        throw new NotImplementedException();
    }

    public override void Input()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }

    public override void Result()
    {
        throw new NotImplementedException();
    }

    
}