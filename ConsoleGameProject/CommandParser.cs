using ConsoleGameProject.Command;

namespace ConsoleGameProject;

/// <summary>
/// 사용자 입력어 파싱 후 명렁어 객체 생성 및 실행하는 클래스
/// </summary>
public class CommandParser
{
    //사용자 입력 파싱 결과
    private string[] tokens; //공백 기준 분리
    private string commandName; //첫 번째 요소 : 명령어
    private string[] args; // 나머지 요소 : 인자

    /// <summary>
    /// 사용자 입력을 파싱하여 명령어 실행
    /// 성공 시 true, 실패 시 false 반환
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public bool ParseAndExecute(string input)
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
        if (!Define.Commands.TryGetValue(commandName, out Func<ICommand> commandFactory))
        {
            //실패
            Util.TerminalError("오류 :존재하지 않는 명령어입니다.",
                "404_COMMAND_NOT_FOUND");
            return false;
        }

        // 명령어가 현재 사용 가능한 명령어인지 체크
        if (!GameManager.player.UsableCommand.Contains(commandName))
        {
            Util.TerminalError($"오류 : '{commandName}' 명령어는 사용할 수 없습니다. 복구가 필요합니다.",
                "403_COMMAND_LOCKED");
            return false;

        }
        

        //등록됐다면 명령어 객체 생성
        ICommand command = commandFactory();
            
        //실행
        bool isSuccess = command.Execute(args);

        if (!isSuccess)
        {
            //출력문구
            Util.TerminalError("오류 : 명령어 실행에 실패했습니다.",
                "500_COMMAND_EXECUTION_FAILED");
        }
                
            
        return isSuccess;

    }
 
    
}