using UnityEngine;

namespace OffersFeature.View
{
    public class HorizontalRewardRootFactory
    {
        private readonly HorizontalRewardRoot _prefab;

        public HorizontalRewardRootFactory(HorizontalRewardRoot prefab)
        {
            _prefab = prefab;
        }

        public HorizontalRewardRoot Create()
        {
            var view = Object.Instantiate(_prefab);
            return view;
        }
    }
}