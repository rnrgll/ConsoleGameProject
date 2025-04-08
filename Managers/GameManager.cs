namespace ConsoleGameProject;

public static class GameManager
{

    private static bool isRunning;
    private static RoomManager roomManager;
    private static Player player;
    private static CommandParser parser;
    
    
    public static void Run()
    {
        Start();
        
        //메인 루프
        while (isRunning)
        {
            roomManager.UpdateCurrentRoom();
        }
        
        End();
    }


    
    /// <summary>
    /// 게임 초기 설정
    /// </summary>
    private static void Start()
    {
        //게임 설정
        isRunning = true;

        roomManager = new RoomManager();
        player = new Player();
        parser = new CommandParser();
    }

    /// <summary>
    /// 게임 마무리 작업
    /// </summary>
    private static void End()
    {
        
    }
}