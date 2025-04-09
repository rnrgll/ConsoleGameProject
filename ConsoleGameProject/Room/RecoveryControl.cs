namespace ConsoleGameProject;

public class RecoveryControl : Room, IRecoverable
{
    
    public string RecoverableModule => "shop";
    public bool isRecovered { get; set; }
    public Action RecoverHint { get; set; }


    public RecoveryControl()
    {
        Name = "Recovery Control Room - 복원 컨트롤 룸";
        //Description = "시스템 복원 모듈이 이곳에서 작동됩니다. 마지막 점검이 필요합니다.";
        
        Connections["west"] = "VirusZone";
        Connections["north"] = "DataCacheRoom"; 
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