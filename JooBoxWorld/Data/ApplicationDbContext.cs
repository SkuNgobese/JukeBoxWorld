using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JooBoxWorld.Models;

namespace JooBoxWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JooBoxWorld.Models.Address> Addresses { get; set; }
        public DbSet<JooBoxWorld.Models.Contact> Contacts { get; set; }
        public DbSet<JooBoxWorld.Models.FieldManager> FieldManagers { get; set; }
        public DbSet<JooBoxWorld.Models.Voucher> Vouchers { get; set; }
        public DbSet<JooBoxWorld.Models.Agent> Agents { get; set; }
    }
}
