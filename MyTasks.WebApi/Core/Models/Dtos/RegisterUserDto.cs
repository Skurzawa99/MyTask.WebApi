namespace MyTasks.WebApi.Models.Dtos
{
    public class RegisterUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
