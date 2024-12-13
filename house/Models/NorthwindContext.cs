using Microsoft.EntityFrameworkCore;

namespace house.Models
{
   
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { }

    }
}
