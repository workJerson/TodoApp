namespace TodoApp.Utils.Response
{
    public class ErrorField
    {
        public ErrorField(string fieldId, string message)
        {
            FieldId = fieldId;
            Message = message;
        }

        public string FieldId { get; private set; }
        public string Message { get; private set; }
    }
}