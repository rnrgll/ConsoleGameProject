namespace ConsoleGameProject;

public class Player
{
    public string Name { get; set; } 
    
    public HashSet<string> UsableCommand { get; private set; } = new HashSet<string>();

    public Player()
    {
        //게임 시작 시 사용 가능한 command들 추가
        UsableCommand.Add("start");
        UsableCommand.Add("recover");
    }


    // public Queue<string> CombatLogs { get; } = new Queue<string>();

    // public bool IsLoggedOut { get; set; } = false;

    // 추가로: 로그 출력용
    // public void AddLog(string log)
    // {
    //     if (CombatLogs.Count > 20) CombatLogs.Dequeue();
    //     CombatLogs.Enqueue(log);
    // }

    public void AddModule(Command.Command command)
    {
        UsableCommand.Add(command.Name);
    }
    

    
}