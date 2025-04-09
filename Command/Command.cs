namespace ConsoleGameProject.Command;

public abstract class Command
{
    public string Name { get; protected set; }
    public string UsageHint { get; protected set; }       //사용법
    
    // 복원 시 실행되는 이벤트
    public Action OnRecovered { get; protected set; }


    protected Command(string name, string usageHint)
    {
        Name = name;
        UsageHint = usageHint;
        OnRecovered  = () =>
        {
            //복원 메시지 출력
            Util.TerminalPrint($"모듈 '{Name}' 복원이 완료되었습니다!", ConsoleColor.Green);
            Util.TerminalPrint(UsageHint);
            GameManager.player.AddModule(this);
        }; 
    }
}