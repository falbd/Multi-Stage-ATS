namespace Multi_Stage_ATS.Models
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
