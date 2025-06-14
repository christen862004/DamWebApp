using Microsoft.CodeAnalysis.CodeActions;
using System.ComponentModel.DataAnnotations;

namespace DamWebApp.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

    }
}
