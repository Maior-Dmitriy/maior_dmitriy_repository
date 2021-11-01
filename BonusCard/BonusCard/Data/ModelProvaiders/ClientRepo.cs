using BonusCard.Data.Interfaces;
using BonusCard.Models;

namespace BonusCard.Data.RepoClasses
{
    public class ClientRepo : GeneralImplementationRepo<Client>, IClientRepositoriy
    {
        public ClientRepo(BonusSystemDbContext model)
            :base(model)
        {

        }
    }
}
