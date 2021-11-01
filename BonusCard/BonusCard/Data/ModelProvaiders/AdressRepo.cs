using BonusCard.Data.Interfaces;
using BonusCard.Models;

namespace BonusCard.Data.RepoClasses
{
    public class AdressRepo : GeneralImplementationRepo<Adress>, IAdressRepositoriy
    {
        public AdressRepo(BonusSystemDbContext model)
            :base(model)
        {
            //For the next extention and changes
        }
    }
}
