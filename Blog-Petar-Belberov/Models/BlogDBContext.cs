using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog_Petar_Belberov.Models
{
    public class BlogDBContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BlogDBContext Create()
        {
            return new BlogDBContext();
        }
    }
}