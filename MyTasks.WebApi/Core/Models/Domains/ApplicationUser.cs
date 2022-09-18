using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MyTasks.WebApi.Models.Domains
{
    public class ApplicationUser 
    {
        public ApplicationUser()
        {
            Tasks = new Collection<Tasks>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
