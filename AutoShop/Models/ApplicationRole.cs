using Microsoft.AspNet.Identity.EntityFramework;

namespace AutoShop.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public string Description { get; set; }
    }
}