using OffersFeature.Controller;
using OffersFeature.Model;
using OffersFeature.View;
using UnityEngine;
using UnityEngine.UI;

namespace StartLogic
{
    public class StartScript : MonoBehaviour
    {
        [SerializeField] private Button _openOfferButton;
        [SerializeField] private Offers _offers;
        [SerializeField] private Transform _windowRoot;

        private IOfferController _offerController;

        private void Start()
        {
            var offerModelFactory = new OfferModelFactory(_offers.OfferInfos[0], _offers.OfferConfigs[0]);
            var offerModel = offerModelFactory.Create();
            
            var offerViewFactory = new OfferViewFactory(_windowRoot);
            var offerView = offerViewFactory.Create();
            offerView.SetModel(offerModel);
            
            var offerFactory = new OfferControllerFactory(offerModel, offerView);
            _offerController = offerFactory.Create();
            
            _openOfferButton.onClick.AddListener(_offerController.ShowView);
        }

        private void OnDestroy()
        {
            _offerController?.Dispose();
            _openOfferButton.onClick.RemoveAllListeners();
        }
    }
}
