using System;
using System.ComponentModel.DataAnnotations;

namespace BonusCard.Models
{
    public partial class Client
    {
        public Guid ClientID { get; set; }
        [Required]
        [RegularExpression("(^[A-Z][a-zA-Z]*$)", ErrorMessage = "Is not correct")]        
        public string Name { get; set; }
        [Required]
        [RegularExpression("(^[A-Z][a-zA-Z]*$)", ErrorMessage = "Is not correct")]
        public string Surname { get; set; }
        [Display(Name = "Date of birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [RegularExpression(@"(?<=(^|\n)(38)?)(063|066|067|068|095|096|097|098|099|044)\d{7}(?=\r?\n|$)", ErrorMessage = "Format is not valid.")]
        [Display(Name = "Phone               +380")]
        public string PhoneNumber { get; set; }

        public Guid BonusCardID { get; set; }

        public Adress Adress { get; set; }
        public ClientBonusCard  BonusCard {get; set;}
        public PersonalDiscount Discount {get; set;}
    }
}
