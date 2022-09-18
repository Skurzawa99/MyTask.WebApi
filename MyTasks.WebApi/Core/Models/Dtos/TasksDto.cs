using System.ComponentModel.DataAnnotations;

namespace MyTasks.WebApi.Models.Dtos
{
    public class TasksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CategoryId { get; set; }
        public bool IsExecuted { get; set; }
        public string UserId { get; set; }
    }
}
