using BonusCard.Data.Interfaces;
using BonusCard.Models;

namespace BonusCard.Data.ModelProvaiders
{
    public class ClientWithAdressRepo : GeneralImplementationRepo<ClientWithAdress>, IClientWithAdress
    {
        public ClientWithAdressRepo(BonusSystemDbContext model)
                : base(model)
        {
            
        }

        /// <summary>
        /// Add client and him adress to context
        /// </summary>
        /// <param name="client">Client and adress info</param>
        public void AddClientWithAdress(ClientWithAdress client)
        {
            client.Adress.Client = client.Client;
            context.Add(client.Client);
            context.Add(client.Adress);
        }
    }
}
