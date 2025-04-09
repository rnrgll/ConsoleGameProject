namespace ConsoleGameProject.Command;

public abstract class Command : ICommand
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
            GameManager.player.AddCommand(this);
            
            //복원 메시지 출력
            Util.PrintProgressBar($"모듈 {Name} 복원 중");
            Util.TerminalLog($"모듈 '{Name}' 복원이 완료되었습니다!", ConsoleColor.Green);
            Util.TerminalLog(UsageHint);
            Console.WriteLine();
        }; 
    }
    
    public abstract bool Execute(string[] args);
}