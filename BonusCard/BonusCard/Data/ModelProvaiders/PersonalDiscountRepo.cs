using BonusCard.Data.Interfaces;
using BonusCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonusCard.Data.RepoClasses
{
    public class PersonalDiscountRepo : GeneralImplementationRepo<PersonalDiscount>, IPersonalDiscountRepositoriy
    {
        public PersonalDiscountRepo(BonusSystemDbContext model)
            :base(model)
        {

        }
        //For the next extention and changes
    }
}
