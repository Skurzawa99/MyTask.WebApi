using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;

namespace MyTasks.WebApi.Models.Converters
{
    public static class TasksConverter
    {
        public static TasksDto ToDto(this Tasks model)
        {
            return new TasksDto
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Date = model.Date,
                IsExecuted = model.IsExecuted,
                UserId = model.UserId
            };
        }

        public static IEnumerable<TasksDto> ToDtos(this IEnumerable<Tasks> model)
        {
            if (model == null)
                return Enumerable.Empty<TasksDto>();

            return model.Select(x => x.ToDto());
        }

        public static Tasks ToDao(this TasksDto model)
        {
            return new Tasks
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Date = model.Date,
                IsExecuted = model.IsExecuted,
                UserId = model.UserId
            };
        }
    }

}
