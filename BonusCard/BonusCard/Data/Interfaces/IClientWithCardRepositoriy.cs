using BonusCard.Models;
using System;

namespace BonusCard.Data.Interfaces
{
    public interface IClientWithCardRepositoriy : IRepositoriy<ClientWithCard>
    {
        void AddClientWithCard(Client client);
        decimal GetCardBalance(ClientBonusCard card);
        ClientWithCard SearchByCardNum(Guid Id);
        public ClientWithCard SearchByClientPhone(string phone);
    }
}
