using System;
using OffersFeature.View;

namespace OffersFeature.Model
{
    public interface IObservableOfferModel
    {
        event Action<OfferViewConfig> OnChangeModel;
    }
}