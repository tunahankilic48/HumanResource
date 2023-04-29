namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //Sorulacak : Personel girişi email mi olacak username mi olacak ?
        //ToDo : Data Anotation eklenecek , kısıtlamalar eklenebilir
    }
}
