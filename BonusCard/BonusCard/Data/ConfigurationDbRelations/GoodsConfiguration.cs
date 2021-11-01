
using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusCard.Data.ConfigurationRelations
{
    public class GoodsConfiguration : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.ToTable("Goods");
            builder.Property(goods => goods.GoodsID).ValueGeneratedOnAdd().HasColumnName("GoodsID").IsRequired();
            builder.Property(goods => goods.GoodsName).HasColumnName("GoodsName").HasMaxLength(20).IsRequired();
            builder.Property(goods => goods.Price).HasColumnName("Price").IsRequired();
            builder.Property(goods => goods.InStock).HasColumnName("InStock").HasColumnType("bit");
            builder.HasOne(goods => goods.PersonalDiscount).WithMany(discount => discount.Goods).HasForeignKey(p => p.PersonalDiscountID);
            builder.Property(goods => goods.PersonalDiscountID).ValueGeneratedOnAdd();
            builder.HasIndex(goods => goods.GoodsName); 
        }
    }
}
