using CommonVIew;
using UnityEngine;

namespace OffersFeature.View
{
    public class OfferViewFactory
    {
        private readonly IIconHelper m_IconHelper;
        private readonly Transform _windowRoot;
        private readonly OfferRewardViewFactory _rewardFactory;
        private readonly HorizontalRewardRootFactory _horizontalRootFactory;

        public OfferViewFactory(
            IIconHelper iconHelper,
            Transform windowRoot,
            OfferRewardViewFactory rewardFactory, 
            HorizontalRewardRootFactory horizontalRootFactory)
        {
            m_IconHelper = iconHelper;
            _windowRoot = windowRoot;
            _rewardFactory = rewardFactory;
            _horizontalRootFactory = horizontalRootFactory;
        }

        public IOfferView Create()
        {
            var offerViewPrefab = Resources.Load<OfferView>("Prefabs/OfferViews/OfferView");
            var view = Object.Instantiate(offerViewPrefab, _windowRoot, false);
            view.Init(m_IconHelper, _rewardFactory, _horizontalRootFactory);
            return view;
        }
    }
}