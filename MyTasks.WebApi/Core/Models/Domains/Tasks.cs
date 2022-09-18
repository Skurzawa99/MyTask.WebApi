using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyTasks.WebApi.Models.Domains
{
    public class Tasks
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CategoryId { get; set; }
        public bool IsExecuted { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public Category Category { get; set; }
    }
}
