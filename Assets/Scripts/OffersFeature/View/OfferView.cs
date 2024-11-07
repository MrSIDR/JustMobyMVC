using System;
using Assets.SimpleLocalization.Scripts;
using CommonVIew;
using OffersFeature.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OffersFeature.View
{
    public class OfferView : MonoBehaviour, IOfferView
    {
        public event Action OnClickClose;
        public event Action OnClickBuy;

        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private TMP_Text _descriptionText;
        
        [SerializeField] private Button _closeButton;
        [SerializeField] private BuyButton _buyButton;

        private float _price;
        private bool _wasSetup;
        private IObservableOfferModel _observableOfferModel;

        public void Init()
        {
            _closeButton.onClick.RemoveListener(ClickCloseView);
            _closeButton.onClick.AddListener(ClickCloseView);
            
            _buyButton.Init(ClickBuyButton);
        }
        
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetModel(IObservableOfferModel observableOfferModel)
        {
            if (_observableOfferModel != null)
            {
                UnsubscribeModel();
            }
            
            _observableOfferModel = observableOfferModel;
            SubscribeModel();
        }

        public void SetupView(OfferViewConfig offerViewConfig)
        {
            if (offerViewConfig == null)
            {
                _wasSetup = false;
                Debug.LogError($"{nameof(offerViewConfig)} is null!");
                return;
            }

            _price = offerViewConfig.Price;
            _buyButton.SetupView(_price, offerViewConfig.Discount);

            _headerText.text = offerViewConfig.HeaderText;
            _descriptionText.text = offerViewConfig.DescriptionText;
            
            _wasSetup = true;
        }

        private void ClickCloseView()
        {
            OnClickClose?.Invoke();
        }

        private void ClickBuyButton()
        {
            if (!_wasSetup)
            {
                Debug.LogError($"View {nameof(OfferView)} has not been set!");
                return;
            }
            
            OnClickBuy?.Invoke();
        }
        
        private void SubscribeModel()
        {
            _observableOfferModel.OnChangeModel -= SetupView;
            _observableOfferModel.OnChangeModel += SetupView;
        }
        
        private void UnsubscribeModel()
        {
            _observableOfferModel.OnChangeModel -= SetupView;
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
            UnsubscribeModel();
        }
    }
}