using OffersFeature.Model;
using OffersFeature.View;

namespace OffersFeature.Controller
{
    public class OfferControllerFactory
    {
        private readonly IOfferModel m_OfferModel;
        private readonly IOfferView m_OfferView;

        public OfferControllerFactory(IOfferModel offerModel, IOfferView offerView)
        {
            m_OfferModel = offerModel;
            m_OfferView = offerView;
        }

        public IOfferController Create()
        {
            return new OfferController(m_OfferModel, m_OfferView);
        }
    }
}