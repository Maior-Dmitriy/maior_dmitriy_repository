using BonusCard.Data.Interfaces;
using BonusCard.Models;
namespace BonusCard.Data.RepoClasses
{
    public class GoodsRepo : GeneralImplementationRepo<Goods>, IGoodsRepositoriy
    {
        public GoodsRepo(BonusSystemDbContext model)
            : base(model)
        {

        }
        //For the next extention and changes
    }
}
