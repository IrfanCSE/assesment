using System.ComponentModel.DataAnnotations;

namespace primetechmvc.DTO
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Please Enter Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string password { get; set; }
    }
}