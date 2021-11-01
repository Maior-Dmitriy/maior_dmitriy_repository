using System;
using System.Collections.Generic;

namespace BonusCard.Models
{
    public partial class PersonalDiscount
    {
        public Guid PersonalDiscountID { get; set;}
        public float DiscountCoefficent { get; set;}
        public Guid Client { get; set; }

        public Client ClientDiscount { get; set; }
        public ICollection<Goods> Goods { get; set; }
    }
}
