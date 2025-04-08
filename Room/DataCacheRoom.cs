namespace ConsoleGameProject;

public class DataCacheRoom : Room
{
    public DataCacheRoom()
    {
        Name = "Data Cache Room - 데이터 캐시 룸";
        Description = "손상된 데이터가 흩어져 있습니다. 중요한 정보가 숨어 있을지도 모릅니다.";
        Connections["northwest"] = "ErrorLogRoom";
        Connections["south"] = "RecoveryControlRoom";
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