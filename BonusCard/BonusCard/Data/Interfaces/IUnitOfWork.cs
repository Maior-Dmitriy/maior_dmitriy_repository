using System;

namespace BonusCard.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdressRepositoriy Adress {get;}
        IClientBonusCardRepositoriy BonusCard { get; }
        IClientRepositoriy Client { get;}
        IGoodsRepositoriy Goods { get; }
        IPersonalDiscountRepositoriy PersonalDiscount { get; }
        IClientWithCardRepositoriy ClientWithCard { get; }
        IClientWithAdress ClientWithAdress { get; }
        int Complete();
    }
}
