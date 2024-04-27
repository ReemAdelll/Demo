using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class Demo_dbcontext: DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public Demo_dbcontext()
        {
            
        }
        public Demo_dbcontext(DbContextOptions options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-ATD1VHG\\SQLEXPRESS; Initial Catalog=MVC_DB; Integrated Security= True; Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
