using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.ViewModels
{
        public class UserViewModel
        {
                public string Id { get; set; }

                [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
                [Display(Name = "Username")]
                public string UserName { get; set; }
                [Required, EmailAddress]
                public string Email { get; set; }
                [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
                public string Password { get; set; }

                public UserViewModel()
                {
                }

                public UserViewModel(IdentityUser user)
                {
                        Id = user.Id;
                        UserName = user.UserName;
                        Email = user.Email;
                        Password = user.PasswordHash;
                }
        }
}
