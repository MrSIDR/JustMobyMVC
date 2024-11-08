using System;

namespace OffersFeature.Controller
{
    public interface IOfferController : IDisposable
    {
        string GetOfferId();
        void ShowView();
        void SetDiscount(bool hasDiscount);
    }
}