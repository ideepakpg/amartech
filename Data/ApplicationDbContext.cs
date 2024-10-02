using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using amartech.Models.Admin;

namespace amartech.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PricingRequest> pricingRequests { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
    }
}
