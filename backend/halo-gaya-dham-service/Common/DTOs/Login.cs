namespace Common.DTOs
{
    public class Login
    {
        public bool isUser { get; set; }
        public bool doesPasswordMatch { get; set; }
        public string Message { get; set; }
    }
}