namespace WebApp.Models.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ClientName { get; set; }
        public DateTime? StartDate { get; set; }  
        public DateTime? EndDate { get; set; }   
        public decimal? Budget { get; set; }   
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
