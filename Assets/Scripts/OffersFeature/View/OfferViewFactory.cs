using UnityEngine;

namespace OffersFeature.View
{
    public class OfferViewFactory
    {
        private Transform _windowRoot;

        public OfferViewFactory(Transform windowRoot)
        {
            _windowRoot = windowRoot;
        }

        public IOfferView Create()
        {
            var offerViewPrefab = Resources.Load<OfferView>("Prefabs/OfferViews/OfferView");
            var view = Object.Instantiate(offerViewPrefab, Vector3.zero, Quaternion.identity, _windowRoot);
            view.Init();
            return view;
        }
    }
}