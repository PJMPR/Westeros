using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Web.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Display(Name ="Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login is required.")]
        public string Login { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Address is required.")]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage ="Email and Confirm Email must match. ")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Sex is required.")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(minimum: 1, maximum: 200, ErrorMessage ="Provide valid Age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        public double Height { get; set; }
    }
}
