namespace OffersFeature.Model
{
    public class OfferModelFactory
    {
        private readonly OfferInfo _info;
        private readonly OfferConfig _config;

        public OfferModelFactory(OfferInfo info, OfferConfig config)
        {
            _info = info;
            _config = config;
        }
        
        public IOfferModel Create()
        {
            return new OfferModel(_info, _config);
        }
    }
}