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
        public string Error;

        public FormResult(AlertType type, string error)
        {
            Type = type;
            Error = error;
        }
    }
}