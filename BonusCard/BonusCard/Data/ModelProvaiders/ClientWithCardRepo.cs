using BonusCard.Data.Interfaces;
using BonusCard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BonusCard.Data.ModelProvaiders
{
    public class ClientWithCardRepo : GeneralImplementationRepo<ClientWithCard>, IClientWithCardRepositoriy
    {
        public ClientWithCardRepo(BonusSystemDbContext model)
            : base(model)
        {

        }

        /// <summary>
        /// Add client and him card
        /// </summary>
        /// <param name="client">Client info</param>
        public void AddClientWithCard(Client client)
        {
             var card = new ClientBonusCard()
             {
                 IsActivated = false,
                 Client = client
             };

             client.BonusCard = card;
             context.Add(client);
             context.Add(card);
        }

        /// <summary>
        /// Display card balanse
        /// </summary>
        /// <param name="card">Client card</param>
        /// <returns>Balanse</returns>
        public decimal GetCardBalance(ClientBonusCard card)
        {
            return card.Balanse;
        }


        /// <summary>
        /// Search client by id and return information about client and card
        /// </summary>
        /// <param name="cardID">Card ID for search</param>
        /// <returns>Client and card info</returns>
        public ClientWithCard SearchByCardNum(Guid cardID)
        {
            ClientBonusCard clientCard = context.ClientBonusCard.Where(c => c.ClientBonusCardID.Equals(cardID)).Include(card => card.Client).FirstOrDefault();               

            if (clientCard != null)
            {
                Client client = clientCard.Client;
                ClientWithCard clientWithCard = new ClientWithCard()
                {
                    Client = client,
                    Card = clientCard
                };
                return clientWithCard;
            }
            else
            {
                return null; 
            }
        }

        /// <summary>
        /// Search client by phone number and return information about client and card
        /// </summary>
        /// <param name="phoneNumber">Client phone</param>
        /// <returns>Client and card info</returns>
        public ClientWithCard SearchByClientPhone(string  phoneNumber)
        {
            var result = context.Clients.Where(p => p.PhoneNumber.Equals(phoneNumber)).Include(client => client.BonusCard).FirstOrDefault();

            if (result != null)
            {
                var clientWithCard = new ClientWithCard()
                {
                    Client = result,
                    Card = result.BonusCard
                };

                return clientWithCard;
            }
            else
            {
                return null;
            }
        }
    }
}
