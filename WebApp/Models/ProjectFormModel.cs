using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models
{
    public class ProjectFormModel
    {

        public int Id { get; set; }  // för att identifiera projektet

        [Required]
        [StringLength(20)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public string ClientName { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
    }
}
