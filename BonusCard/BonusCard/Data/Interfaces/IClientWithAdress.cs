
using BonusCard.Models;

namespace BonusCard.Data.Interfaces
{
    public interface IClientWithAdress : IRepositoriy<ClientWithAdress>
    {
        void AddClientWithAdress(ClientWithAdress client);
    }
}
