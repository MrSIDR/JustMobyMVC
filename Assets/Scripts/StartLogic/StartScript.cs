using CommonVIew;
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
        [SerializeField] private IconConfig _IconConfig;
        [SerializeField] private OfferRewardView _offerRewardViewPrefab;
        [SerializeField] private HorizontalRewardRoot _horizontalRewardRootPrefab;
        [Range(0, 1)]
        [SerializeField] private int _modelIndex;

        private IOfferController _offerController;

        private void Start()
        {
            var offerModelFactory = new OfferModelFactory(_offers.OfferInfos[_modelIndex], _offers.OfferConfigs[_modelIndex]);
            var offerModel = offerModelFactory.Create();

            var iconHelper = new IconHelper(_IconConfig);
            var offerRewardViewFactory = new OfferRewardViewFactory(_offerRewardViewPrefab);
            var horizontalRewardRootFactory = new HorizontalRewardRootFactory(_horizontalRewardRootPrefab);
            
            var offerViewFactory = new OfferViewFactory(iconHelper, _windowRoot, offerRewardViewFactory, horizontalRewardRootFactory);
            var offerView = offerViewFactory.Create();
            offerView.SetModel(offerModel);
            
            var offerFactory = new OfferControllerFactory(offerModel, offerView);
            _offerController = offerFactory.Create();
            
            _openOfferButton.onClick.AddListener(_offerController.ShowView);
        }

        [ContextMenu("Enable Discount")]
        public void EnableDiscount()
        {
            _offerController.SetDiscount(true);
        }
        
        [ContextMenu("Disable Discount")]
        public void DisableDiscount()
        {
            _offerController.SetDiscount(false);
        }
        
        private void OnDestroy()
        {
            _offerController?.Dispose();
            _openOfferButton.onClick.RemoveAllListeners();
        }
    }
}
