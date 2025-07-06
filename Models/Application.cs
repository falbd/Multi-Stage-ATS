namespace Multi_Stage_ATS.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = null!;
        public int StageId { get; set; }
        public Stage Stage { get; set; } = null!;
        public DateTime AppliedOn { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
