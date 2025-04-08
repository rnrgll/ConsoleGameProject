using ConsoleGameProject.Command;

namespace ConsoleGameProject;

/// <summary>
/// 사용자 입력어 파싱 후 명렁어 객체 생성 및 실행하는 클래스
/// </summary>
public class CommandParser
{
    //명령어 이름 - 명령어 객체 생성 팩토리 함수 매핑하는 딕셔너리
    private Dictionary<string, Func<ICommand>> commands;
    
    //사용자 입력 파싱 결과
    private string[] tokens; //공백 기준 분리
    private string commandName; //첫 번째 요소 : 명령어
    private string[] args; // 나머지 요소 : 인자
    
    //생성자
    public CommandParser()
    {
        
        commands = new Dictionary<string,Func<ICommand>>(20);
        
        InitializeCommand();
        
        
    }

    /// <summary>
    /// 명령어 이름과 명령어 객체 생성 함수 딕셔너리에 등록
    /// </summary>
    public void InitializeCommand()
    { 
        commands["move"] = () => new MoveCommand();
        commands["scan"] = () => new ScanCommand();
        commands["recover"] = () => new RecoverCommand();
        
        //추가
       

    }

    /// <summary>
    /// 사용자 입력을 파싱하여 명령어 실행
    /// 성공 시 true, 실패 시 false 반환
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public bool TryParseCommands(string input)
    {
        //빈 문자열, 공백 입력시 무시
        if (string.IsNullOrWhiteSpace(input)) return false;
        
        //공백 기준 분리, 빈 문자열 제거
        tokens = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        //아무 입력 없으면 실패 처리
        if (tokens.Length == 0) return false;
        
        //파싱 결과
        commandName = tokens[0].ToLower();
        args = tokens.Skip(1).ToArray();

        //딕셔너리에 등록된 명령어인지 확인
        if (commands.TryGetValue(commandName, out Func<ICommand> commandFactory))
        {
            //등록됐다면 명령어 객체 생성
            ICommand command = commandFactory();
            //실행
            command.Execute(args);
            return true;
        }

        //실패
        return false;



    }
 
    
}