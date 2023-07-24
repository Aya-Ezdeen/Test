using Microsoft.AspNetCore.Identity;

namespace Test.web.Models
{
    public class User:IdentityUser
    {
        public bool IsDelete { get; set; }
    }
}
