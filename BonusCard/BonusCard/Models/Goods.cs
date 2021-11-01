using System;
namespace BonusCard.Models
{
    public partial class Goods
    {
        public Guid GoodsID { get; set; }
        public string GoodsName { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public Guid PersonalDiscountID { get; set; }

        public PersonalDiscount PersonalDiscount {get; set;}
    }
}
