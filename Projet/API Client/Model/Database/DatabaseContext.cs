using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API_Client.Model
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BankTransfer>()
               .HasOne(x => x.ExpeditorAccount)
               .WithMany(x => x.BankTransferExpiditor)
               .HasForeignKey(x => x.ExpeditorAccountId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BankTransfer>()
               .HasOne(x => x.ReceiverAccount)
               .WithMany(x => x.BankTransferReceiver)
               .HasForeignKey(x => x.ReceiverAccountId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankTransfer> BankTransfers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
