using MemberRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemberRegister.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        protected async override void OnModelCreating(ModelBuilder builder)
        {
            await SeedData.InitSeedAsync(builder);
        }

        public virtual DbSet<Member> Member { get; set; }
    }
}
