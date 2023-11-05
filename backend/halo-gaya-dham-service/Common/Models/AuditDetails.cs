namespace Common.Models
{
    public class AuditDetails
    {
        public DateTime? AddedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? EditedOn { get; set; }
        public string EditedBy { get; set; }
    }
}
