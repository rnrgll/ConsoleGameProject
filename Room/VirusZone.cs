namespace ConsoleGameProject;

public class VirusZone : Room
{
    public VirusZone()
    {
        Name = "Virus Zone - 바이러스 존";
        Description = "치명적인 바이러스가 떠돌고 있습니다. 접근이 위험합니다.";
        
        Connections["north"] = "TerminalHub";
        Connections["east"] = "RecoveryControlRoom";
    
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