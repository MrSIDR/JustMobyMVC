namespace OffersFeature.Model
{
    public interface IOfferModel : IObservableOfferModel
    {
        string Id { get; }

        void SetDiscount(bool hasDiscount);
        float GetCurrentPrice();
        void RefreshView();
    }
}