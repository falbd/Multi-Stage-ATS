namespace Multi_Stage_ATS.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
