using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Identity.ViewModels;

public class SignUpViewModel
{
    public SignUpViewModel()
    {
        
    }

    public SignUpViewModel(string userName, string email, string password,string passwordConfirm, string phone)
    {
        UserName = userName;
        Email = email;
        Password = password;
        PasswordConfirm = passwordConfirm;
        Phone = phone;
    }
    [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
    [Display(Name = "Kullanıcı Adı : ")]
    public string UserName { get; set; }
    [EmailAddress(ErrorMessage = "Geçerli bir eposta adresi giriniz")]
    [Required(ErrorMessage = "Eposta boş geçilemez")]
    [Display(Name = "Eposta : ")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Şifre boş geçilemez")]
    [Display(Name = "Şifre : ")]
    public string Password { get; set; }
    [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor")]
    [Required(ErrorMessage = "Şifre tekrar boş geçilemez")]
    [Display(Name = "Şifre Tekrar : ")]
    public string PasswordConfirm { get; set; }
    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
    [Required(ErrorMessage = "Telefon boş geçilemez")]
    [Display(Name = "Telefon : ")]
    public string Phone { get; set; }
}
