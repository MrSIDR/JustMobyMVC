using OffersFeature.Model;
using OffersFeature.View;
using UnityEngine;

namespace OffersFeature.Controller
{
    public class OfferController : IOfferController
    {
        private readonly IOfferModel _offerModel;
        private readonly IOfferView _offerView;

        public OfferController(IOfferModel offerModel, IOfferView offerView)
        {
            _offerModel = offerModel;
            _offerView = offerView;

            Subscribe();
            _offerModel.RefreshView();
        }

        public void ShowView()
        {
            _offerView.SetActive(true);
        }

        private void HideView()
        {
            _offerView.SetActive(false);
        }

        private void BuyOffer()
        {
            if (true) //check can buy
            {
                Debug.Log($"Offer was bought with price {_offerModel.GetPrice()}");
            }
        }

        private void Subscribe()
        {
            _offerView.OnClickBuy -= BuyOffer;
            _offerView.OnClickBuy += BuyOffer;
            
            _offerView.OnClickClose -= HideView;
            _offerView.OnClickClose += HideView;
        }
        
        private void Unsubscribe()
        {
            _offerView.OnClickBuy -= BuyOffer;
            _offerView.OnClickClose -= HideView;
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
