namespace ConsoleGameProject;

public interface IRecoverableRoom
{
    public string RecoverableModule { get; }
    public bool isRecoverd { get; set; }
    public Action RecoverHint { get; protected set; }

}