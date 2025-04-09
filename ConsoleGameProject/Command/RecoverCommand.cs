namespace ConsoleGameProject.Command;

public class RecoverCommand : Command, ICommand
{
    public RecoverCommand():base("recover", Define.CommandHints.Recover)
    {
    }


    public bool Execute(string[] args)
    {
        // 명령어 : recover module [모듈명]
        // - 인자가 module, 모듈명 2개여야 한다. = args length == 2 (완)
        // - 첫번째 인자가 module이어야 한다. (완)
        // - 현재 방이 복구 가능한 방인지 확인 (완)
        // - 입력한 모듈명이 현재 복구 가능한 모듈과 일치하는지 체크 (완)
        // - 이미 복원한 모듈이면 -> 이미 복원한 모듈임을 출력 (완)
        // - 최종 성공 시 복구 완료 메시지 출력 & 복구 처리 (완)


        if (args.Length != 2 || !string.Equals(args[0].ToLower(), "module"))
        {
            Util.TerminalError("오류 : 명령어 인자가 올바르지 않습니다.",
                "400_INVALID_ARGUMENT");
            return false;
        }

        string moduleName = args[1].ToLower();

        if (GameManager.roomManager.CurRoom is not IRecoverableRoom recoverableRoom)
        {
            Util.TerminalError("오류 : 복구할 수 있는 모듈이 없습니다.", "403_RECOVERY_FORBIDDEN");
            return false;
        }

        if (!recoverableRoom.RecoverableModule.Equals(moduleName))
        {
            Util.TerminalError($"오류 : '{moduleName}' 모듈을 복구할 수 없습니다.", "403_MODULE_NOT_AVAILABLE");
            return false;
        }

        if (GameManager.player.UsableCommand.Contains(moduleName))
        {
            Util.TerminalError($"오류 : '{moduleName}' 모듈은 이미 복구되었습니다.");
            return false;
        }

        //모듈 복구 처리
        if (Define.Commands.TryGetValue(moduleName, out var moduleFactory))
        {
            Command recoveredModule = moduleFactory() as Command;
            recoveredModule.OnRecovered?.Invoke();
            recoverableRoom.isRecoverd = true;
            return true;


        }

        return false;

    }
}