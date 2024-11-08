using UnityEngine;

namespace OffersFeature.View
{
    public class OfferRewardViewFactory
    {
        private readonly OfferRewardView _prefab;

        public OfferRewardViewFactory(OfferRewardView prefab)
        {
            _prefab = prefab;
        }
        
        public IOfferRewardView Create()
        {
            var view = Object.Instantiate(_prefab);
            return view;
        }
    }
}