using INDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Data
{
    public class INDWalksDbContext : DbContext
    {
        public INDWalksDbContext(DbContextOptions<INDWalksDbContext> options):base(options)
        {
            
        }

        DbSet<Difficulty> Difficulties { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Walk> Walks { get; set; }
    }
}
