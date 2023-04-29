namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class UpdateProfileDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedDate { get; set; }
        //ToDo : Data Anotation eklenecek
    }
}
