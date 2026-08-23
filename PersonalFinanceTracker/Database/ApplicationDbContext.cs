using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker

{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<Receipt> Receipt { get; set; }
		public DbSet<Vendor> Vendor { get; set; }
		public DbSet<Transaction> Transaction { get; set; }
		public DbSet<SystemSetup> SystemSetup { get; set; }
	}
}
