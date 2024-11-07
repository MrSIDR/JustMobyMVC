using System;
using System.Collections.Generic;
using OffersFeature.View;

namespace OffersFeature.Model
{
    public class OfferModel : IOfferModel
    {
        public event Action<OfferViewConfig> OnChangeModel;
        
        private string _id;
        private float _price;
        private float _discountPrice;
        private bool _hasDiscount;
        private string _headerKey;
        private string _descriptionKey;
        private string _offerIconName;
        private List<OfferReward> _rewards;

        public string Id => _id;

        public OfferModel(OfferInfo info, OfferConfig config)
        {
            _id = info.Id;
            _discountPrice = info.DiscountPrice;
            _hasDiscount = info.HasDiscount;
            _price = info.Price;
            _headerKey = config.HeaderKey;
            _descriptionKey = config.DescriptionKey;
            _offerIconName = config.OfferIconName;
            _rewards = config.Rewards;
        }

        public void SetDiscount(bool hasDiscount)
        {
            _hasDiscount = hasDiscount;
            InvokeChangeModelEvent();
        }

        public float GetPrice()
        {
            return _hasDiscount ? _discountPrice : _price;
        }

        public void RefreshView()
        {
            InvokeChangeModelEvent();
        }

        private void InvokeChangeModelEvent()
        {
            var price = _hasDiscount ? _discountPrice : _price;
            var discount = _hasDiscount ? 1 - _discountPrice / _price : (float?) null;
            
            var config = new OfferViewConfig(
                _headerKey,
                _descriptionKey,
                _rewards,
                price,
                discount,
                _offerIconName);
            
            OnChangeModel?.Invoke(config);
        }
    }
}
