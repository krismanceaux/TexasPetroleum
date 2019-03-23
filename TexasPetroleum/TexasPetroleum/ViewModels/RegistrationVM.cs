using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.ViewModels
{
    public class RegistrationVM
    {
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [MinLength(7, ErrorMessage ="Password must be at least 7 characters long")]
        //[RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?&])[A-Za-z\\d$@$!%*#?&]$", ErrorMessage ="Password must contain at least one special character, one number, and letter")]
        public string Password { get; set; }
    }
}