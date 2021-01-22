using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int IDUser { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập FirstName!!!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập LastName!!!")]
        public string LastName { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Required(ErrorMessage = "Vui lòng nhập Email!!!")]
        public string Email { get; set; }
        
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [Required(ErrorMessage = "Vui lòng nhập Password!!!")]
        [DataType(DataType.Password)]        
        public string Password { get; set; }
        [Required(ErrorMessage = "Error ConfirmPassword!!!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string LoginErrorMessage { get; set; }
       

    }
}