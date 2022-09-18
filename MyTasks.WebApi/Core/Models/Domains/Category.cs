using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyTasks.WebApi.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Tasks = new Collection<Tasks>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
