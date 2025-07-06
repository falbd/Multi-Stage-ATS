namespace Multi_Stage_ATS.DTO
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; } = null!;
        public string ApplicantEmail { get; set; } = null!; 
        public int StageId { get; set; }
        public string StageName { get; set; } = null!;
        public DateTime AppliedOn { get; set; }
        public string? Notes { get; set; }
    }
}
