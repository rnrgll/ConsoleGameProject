namespace ConsoleGameProject;

using RoomKey = ConsoleGameProject.Define.RoomKey;


public class RoomManager
{
    private Dictionary<RoomKey, Room> roomDic;
    private Room curRoom;
    public Room CurRoom => curRoom;
    
    //생성자
    //Room 생성 및 dictionary 에 추가하여 초기 설정하기
    public RoomManager()
    {
        roomDic = new Dictionary<RoomKey, Room>(10);
        InitializeRoom();
    }
    
    /// <summary>
    /// 초기화
    /// </summary>
    public void InitializeRoom()
    { 
        //인스턴스 생성
        //방 종류 : 터미널 허브, 로그 제어실, 복원 컨트롤 룸, 바이러스 존, 타이틀 씬, 인트로씬, 엔딩 씬
        
        
        //딕셔너리에 추가
        roomDic[RoomKey.Title] = new Title();
        roomDic[RoomKey.Intro] = new Intro();
        roomDic[RoomKey.Ending] = new Ending();
        roomDic[RoomKey.TerminalHub] = new TermialHub();
        roomDic[RoomKey.LogControlRoom] = new LogControl();
        roomDic[RoomKey.SystemCore] = new SystemCore();
        roomDic[RoomKey.VaccineCore] = new VaccineCore();
        
        
        //현재 방 설정
        // curRoom = roomDic[RoomKey.Title];
        MoveTo(RoomKey.Title);
        
    }
    
    
    
    public void UpdateCurrentRoom()
    {
        curRoom.Input();
    }


    public bool MoveTo(RoomKey roomKey)
    {
        if (roomDic.TryGetValue(roomKey, out var nextRoom))
        {
            curRoom = nextRoom;

            if (nextRoom is not Intro && nextRoom is not Ending && nextRoom is not Title)
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

    public Room GetRoom(RoomKey roomKey)
    {
        if (roomDic.TryGetValue(roomKey, out var room))
        {
            return room;
        }

        return null;
    }
}