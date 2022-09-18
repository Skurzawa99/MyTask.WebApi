using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;

namespace MyTasks.WebApi.Models.Converters
{
    public static class CategoryConverter
    {
        public static CategoryDto ToDto(this Category model)
        {
            return new CategoryDto
            {
                Name = model.Name
            };
        }

        public static IEnumerable<CategoryDto> ToDtos(this IEnumerable<Category> model)
        {
            if (model == null)
                return Enumerable.Empty<CategoryDto>();

            return model.Select(x => x.ToDto());
        }

        public static Category ToDao(this CategoryDto model)
        {
            return new Category
            {
                Name = model.Name
            };
        }
    }
}
