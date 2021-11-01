using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusCard.Data.ConfigurationRelations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.Property(client => client.ClientID).ValueGeneratedOnAdd().HasColumnName("ClientID").IsRequired();
            builder.Property(client => client.Name).HasColumnName("Name").HasMaxLength(20).IsRequired();
            builder.Property(client => client.Surname).HasColumnName("Surname").HasMaxLength(20).IsRequired();
            builder.Property(client => client.DateOfBirth).HasColumnType("date").HasColumnName("DateOfBirth");
            builder.Property(client => client.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(14).IsRequired();          
            builder.HasOne(client => client.BonusCard).WithOne(bonusCard => bonusCard.Client).HasForeignKey<Client>(client => client.BonusCardID).IsRequired();
            builder.Property(client => client.BonusCardID).ValueGeneratedOnAdd();
            builder.HasIndex(client => client.Surname);
            builder.HasIndex(client => client.PhoneNumber);
        }
    }
}
