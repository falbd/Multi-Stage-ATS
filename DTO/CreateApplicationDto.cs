namespace Multi_Stage_ATS.DTO
{
    public class CreateApplicationDto
    {
        public int ApplicantId { get; set; }
        public int StageId { get; set; }
        public string? Notes { get; set; }
    }
}
