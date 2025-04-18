namespace ConsoleGameProject.Command;

public class MoveCommand : Command
{
    public MoveCommand() : base("move", Define.CommandHints.Move)
    {
        
    }

    public override bool Execute(string[] args)
    {
        if (args.Length != 1)
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.",
                "400_INVALID_ARGUMENT");
            return false;
        }

        string direction = args[0].ToLower();

        if (GameManager.roomManager.CurRoom.Connections.TryGetValue(direction, out Define.RoomKey nextRoomKey))
        {
            if (GameManager.roomManager.MoveTo(nextRoomKey))
            {
                return true;
            }
        }
        
        Util.TerminalError("오류 발생 : 해당 방향으로 이동할 수 없습니다.",
            "403_DIRECTION_FORBIDDEN");
        return false;
    }
}