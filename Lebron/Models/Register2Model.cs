using System.ComponentModel.DataAnnotations;

namespace Lebron.Models
{
	public class Register2Model
	{
		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
		public string? UserName { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string? Password { get; set; }
        
		[Display(Name = "İsim")]
        [Required(ErrorMessage = "İsim boş geçilemez.")]
        public string? Name { get; set; }
	}
}
