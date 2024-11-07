using System;
using OffersFeature.Model;

namespace OffersFeature.View
{
    public interface IOfferView
    {
        event Action OnClickClose;
        event Action OnClickBuy;
        
        void SetActive(bool isActive);
        void SetModel(IObservableOfferModel observableOfferModel);
    }
}