using Microsoft.AspNetCore.Identity;

namespace Core.Models.ViewModels
{
        public class AuthDetailsViewModel
        {
                public string Cookie { get; set; }
                public IdentityUser User { get; set; }
        }
}
