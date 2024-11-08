using System;

namespace OffersFeature.Controller
{
    public interface IOfferController : IDisposable
    {
        void ShowView();
        void SetDiscount(bool hasDiscount);
    }
}