using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public enum ProjectStatus
    {
        Started,
        Completed
    }

    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string? ClientName { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Budget { get; set; }

        public ProjectStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
