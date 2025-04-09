namespace ConsoleGameProject;

public class RoomManager
{
    private Dictionary<string, Room> roomDic;
    private Room curRoom;
    public Room CurRoom => curRoom;
    
    //생성자
    //Room 생성 및 dictionary 에 추가하여 초기 설정하기
    public RoomManager()
    {
        roomDic = new Dictionary<string, Room>(10);
        InitializeRoom();
    }
    
    /// <summary>
    /// 초기화
    /// </summary>
    public void InitializeRoom()
    { 
        //인스턴스 생성
        //방 종류 : 터미널 허브, 에러 로그룸, 데이터 캐시, 복원 컨트롤 룸, 바이러스 존, 타이틀 씬, 인트로씬, 엔딩 씬
        Room title = new Title();
        Room intro = new Intro();
        Room ending = new Ending();
        Room terminalHub = new TermialHub();
        Room errorLogRoom = new ErrorLogRoom();
        Room virusZone = new VirusZone();
        Room dataCache = new DataCacheRoom();
        Room recoveryRoom = new RecoveryControlRoom();
        
        
        //딕셔너리에 추가
        roomDic["Title"] = title;
        roomDic["Intro"] = intro;
        roomDic["Ending"] = ending;
        roomDic["TerminalHub"] = terminalHub;
        roomDic["ErrorLogRoom"] = errorLogRoom;
        roomDic["VirusZone"] = virusZone;
        roomDic["DataCacheRoom"] = dataCache;
        roomDic["RecoveryControlRoom"] = recoveryRoom;
        
        
        //현재 방 설정
        curRoom = title;
    }
    
    
    
    public void UpdateCurrentRoom()
    {
        curRoom.Render();
        curRoom.Input();
        curRoom.Update();
        curRoom.Result();
    }


    public bool MoveTo(string roomKey)
    {
        if (roomDic.TryGetValue(roomKey, out var nextRoom))
        {
            curRoom = nextRoom;

            if (nextRoom is not Intro)
            {
                Util.TerminalLog($"{curRoom.Name}으로/로 이동합니다...", delay: 500);
                Util.WaitForAnyKey();
            }
            
            Console.Clear();
            curRoom.OnEnter();

            return true;
        }

        return false;
    }

    public Room GetRoom(string roomKey)
    {
        if (roomDic.TryGetValue(roomKey, out var room))
        {
            return room;
        }

        return null;
    }
}