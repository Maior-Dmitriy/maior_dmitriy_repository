
using BonusCard.Data.ConfigurationRelations;
using BonusCard.Models;
using Microsoft.EntityFrameworkCore;

namespace BonusCard.Data
{
    public class BonusSystemDbContext : DbContext
    {
        public BonusSystemDbContext(DbContextOptions<BonusSystemDbContext> options)
                : base(options)
        {
          
        }

        public DbSet<Client> Clients { get; set;}
        public DbSet<Adress> Adreses { get; set; }
        public DbSet<ClientBonusCard> ClientBonusCard { get; set; }
        public DbSet<PersonalDiscount> PersonalDiscount { get; set; }
        public DbSet<Goods> Goods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientBonusCardConfigurations());
            modelBuilder.ApplyConfiguration(new AdressConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalDiscountConfigurations());
            modelBuilder.ApplyConfiguration(new GoodsConfiguration());         
        }
    }
}
