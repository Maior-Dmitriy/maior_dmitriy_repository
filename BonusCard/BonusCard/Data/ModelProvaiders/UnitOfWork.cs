using BonusCard.Data.Interfaces;
using BonusCard.Data.RepoClasses;

namespace BonusCard.Data.ModelProvaiders
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BonusSystemDbContext context;

        public UnitOfWork(BonusSystemDbContext model)
        {
            context = model;
            Adress = new AdressRepo(context);
            Client = new ClientRepo(context);
            Goods = new GoodsRepo(context);
            PersonalDiscount = new PersonalDiscountRepo(context);
            BonusCard = new ClientBonusCardRepo(context);
            ClientWithCard = new ClientWithCardRepo(context);
            ClientWithAdress = new ClientWithAdressRepo(context);
        }

        public IAdressRepositoriy Adress { get; private set; }
        public IClientRepositoriy Client { get; private set; }
        public IGoodsRepositoriy Goods  { get; private set; }
        public IPersonalDiscountRepositoriy PersonalDiscount { get; private set; }
        public IClientBonusCardRepositoriy BonusCard { get; private set; }
        public IClientWithCardRepositoriy ClientWithCard { get; private set; }
        public IClientWithAdress ClientWithAdress { get; private set; }

        /// <summary>
        /// Save changes for DbContext
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
