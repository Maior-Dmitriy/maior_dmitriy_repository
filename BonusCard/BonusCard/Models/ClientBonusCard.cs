using System;
using System.ComponentModel.DataAnnotations;

namespace BonusCard.Models
{
    public partial class ClientBonusCard
    {
        [Display(Name = "Card ID")]
        [Required]
        public Guid ClientBonusCardID { get; set; }
        [Required]        
        public decimal Balanse { get; set; }
        [Required]
        public bool IsActivated { get; set;}

        public Client Client { get; set; }
    }
}
