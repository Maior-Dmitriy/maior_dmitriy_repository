using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusCard.Data.ConfigurationRelations
{
    public class PersonalDiscountConfigurations : IEntityTypeConfiguration<PersonalDiscount>
    {
        public void Configure(EntityTypeBuilder<PersonalDiscount> builder)
        {
            builder.ToTable("PersonalDiscount");
            builder.Property(discount => discount.PersonalDiscountID).ValueGeneratedOnAdd().HasColumnName("DiscountID").IsRequired(); 
            builder.Property(discount => discount.DiscountCoefficent).HasColumnName("DiscountCoefficent").IsRequired();
            builder.HasOne(discount => discount.ClientDiscount).WithOne(client => client.Discount).HasForeignKey<PersonalDiscount>(d => d.Client).OnDelete(DeleteBehavior.ClientSetNull);           
        }
    }
}
