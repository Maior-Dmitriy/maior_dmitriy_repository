using BonusCard.Models;
using System.Collections.Generic;

namespace BonusCard.Data.Interfaces
{
    public  interface IClientBonusCardRepositoriy : IRepositoriy<ClientBonusCard> 
    {
        public IEnumerable<ClientBonusCard> GetAllCardWithClient();
    }
}
