using BonusCard.Data.Interfaces;
using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BonusCard.Data.RepoClasses
{
    public class ClientBonusCardRepo : GeneralImplementationRepo<ClientBonusCard>, IClientBonusCardRepositoriy
    {
        public ClientBonusCardRepo(BonusSystemDbContext model) 
               :base(model)
        {
                
        }

        public IEnumerable<ClientBonusCard> GetAllCardWithClient()
        {
            return context.ClientBonusCard.Include(c => c.Client);
        }
    }
}
