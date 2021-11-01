
using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusCard.Data.ConfigurationRelations
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress");
            builder.Property(adress => adress.AdressID).ValueGeneratedOnAdd().HasColumnName("AdressID").IsRequired();
            builder.Property(adress => adress.Region).HasColumnName("Region").HasMaxLength(20).HasDefaultValue("unknown");
            builder.Property(adress => adress.District).HasColumnName("District").HasMaxLength(20).HasDefaultValue("unknown");
            builder.Property(adress => adress.CityOrVillage).HasColumnName("CityOrVillage").HasMaxLength(20).HasDefaultValue("unknown"); ;
            builder.Property(adress => adress.Street).HasColumnName("Street").HasMaxLength(20).HasDefaultValue("unknown");
            builder.Property(adress => adress.HouseNum).HasColumnName("HouseNum").HasDefaultValue(0);
            builder.Property(adress => adress.FlatNumber).HasColumnName("FlatNumber").HasDefaultValue(0);
            builder.HasOne(adress => adress.Client).WithOne(client => client.Adress).HasForeignKey<Adress>(adress => adress.ClientID);
            builder.Property(adress => adress.ClientID).ValueGeneratedOnAdd();
            builder.HasIndex(adress => adress.CityOrVillage);
        }
    }
}
