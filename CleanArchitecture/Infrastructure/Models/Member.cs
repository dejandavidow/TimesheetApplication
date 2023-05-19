using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models
{
    public class Member : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
