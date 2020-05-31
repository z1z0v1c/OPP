namespace OPP.UI.View.MessageDialogService
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowOKCancelDialog(string message, string title);
    }
}