using amartech.Models.Admin;
using Microsoft.EntityFrameworkCore;

namespace amartech.Data
{
    public class AmartechDbContext : DbContext
    {
        public AmartechDbContext(DbContextOptions<AmartechDbContext> options) : base(options) { }

        public DbSet<PricingRequest> pricingRequests { get; set; }

    }
}
