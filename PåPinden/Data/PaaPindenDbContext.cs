using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PåPinden.Data
{
    public class PaaPindenDbContext(DbContextOptions<PaaPindenDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

    }
}
