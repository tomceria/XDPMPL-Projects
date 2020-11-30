namespace TodoList.ViewModels
{
    public enum AlertType
    {
        INFO,
        SUCCESS,
        DANGER
    }

    public class FormResult
    {
        public AlertType Type;
        public string Message;

        public FormResult(AlertType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}