using System;
using System.ComponentModel.DataAnnotations;

namespace BonusCard.Models
{
    public partial class Adress
    {
        [Required]
        public Guid AdressID { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string District { get; set; }
        [Display(Name = "City/Village")]
        [Required]
        public string CityOrVillage { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public short HouseNum { get; set; }
        [Required]
        public short FlatNumber { get; set;}

        public Guid? ClientID{ get; set;}
        public Client Client { get; set; }
    }
}
