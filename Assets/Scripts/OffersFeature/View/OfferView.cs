using System;
using System.Collections.Generic;
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
        
        private readonly List<IOfferRewardView> _rewards = new List<IOfferRewardView>();
        private readonly List<HorizontalRewardRoot> _horizontalRoots = new List<HorizontalRewardRoot>();

        [SerializeField] private int _maxColumnNumber = 3;
        [SerializeField] private Transform _rewardContainer;
        
        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private TMP_Text _descriptionText;
        
        [SerializeField] private Image _generalImage;
        [SerializeField] private Button _closeButton;
        [SerializeField] private BuyButton _buyButton;
        
        private bool _wasSetup;
        private IObservableOfferModel _observableOfferModel;

        private IIconHelper _iconHelper;
        private HorizontalRewardRootFactory _horizontalRootFactory;
        private OfferRewardViewFactory _rewardViewFactory;

        public void Init(
            IIconHelper iconHelper,
            OfferRewardViewFactory rewardViewFactory,
            HorizontalRewardRootFactory horizontalRootFactory)
        {
            _iconHelper = iconHelper;
            _rewardViewFactory = rewardViewFactory;
            _horizontalRootFactory = horizontalRootFactory;
            
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

            SetupRewards(offerViewConfig.Rewards);
            _buyButton.SetupView(offerViewConfig.Price, offerViewConfig.Discount);

            _generalImage.sprite = _iconHelper.GetSprite(offerViewConfig.OfferIconName);
            _headerText.text = offerViewConfig.HeaderText;
            _descriptionText.text = offerViewConfig.DescriptionText;
            
            _wasSetup = true;
        }

        private void SetupRewards(List<OfferReward> rewards)
        {
            for (int i = 0; i < rewards.Count; i++)
            {
                var rowIndex = i / _maxColumnNumber;

                if (_horizontalRoots.Count <= rowIndex)
                {
                    var horizontalRoot = _horizontalRootFactory.Create();
                    horizontalRoot.transform.SetParent(_rewardContainer, false);
                    _horizontalRoots.Add(horizontalRoot);
                }
                
                _horizontalRoots[rowIndex].SetActive(true);
                if (i >= _rewards.Count)
                {
                    var rewardView = _rewardViewFactory.Create();
                    rewardView.Transform.SetParent(_horizontalRoots[rowIndex].Root, false);
                    _rewards.Add(rewardView);
                }
                
                SetupRewardView(_rewards[i], rewards[i]);
            }

            DisableUnnecessaryView(rewards.Count);
        }

        private void DisableUnnecessaryView(int rewardNumber)
        {
            if (_rewards.Count > rewardNumber)
            {
                for (int i = _rewards.Count - 1; i > rewardNumber - 1; i--)
                {
                    _rewards[i].SetActive(false);
                }
            }
            
            var rowUsedIndex = (rewardNumber - 1) / _maxColumnNumber;
            var rowCreatedIndex = _horizontalRoots.Count - 1;
            if (rowCreatedIndex > rowUsedIndex)
            {
                for (int i = rowCreatedIndex; i > rowUsedIndex; i--)
                {
                    _horizontalRoots[i].SetActive(false);
                }
            }
        }

        private void SetupRewardView(IOfferRewardView view, OfferReward reward)
        {
            var sprite = _iconHelper.GetSprite(reward.ItemName);
            view.SetActive(true);
            view.SetupView(sprite, reward.ItemCount.ToString());
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