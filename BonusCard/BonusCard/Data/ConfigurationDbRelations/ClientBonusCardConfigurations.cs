using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusCard.Data.ConfigurationRelations
{
    public class ClientBonusCardConfigurations : IEntityTypeConfiguration<ClientBonusCard>
    {
        public void Configure(EntityTypeBuilder<ClientBonusCard> builder)
        {
            builder.ToTable("ClientBonusCard");
            builder.Property(bonusCard => bonusCard.ClientBonusCardID).ValueGeneratedOnAdd().HasColumnName("BonusCardID").IsRequired(); ;
            builder.Property(bonusCard => bonusCard.Balanse).HasColumnName("Balance").IsRequired().HasDefaultValue(0);
            builder.Property(bonusCard => bonusCard.IsActivated).HasColumnType("bit").HasColumnName("IsActivated").IsRequired();
        }
    }
}
