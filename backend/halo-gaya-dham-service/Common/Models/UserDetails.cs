namespace Common.Models
{
    public class UserDetails : AuditDetails
    {
        public int AdminLoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}