using UnityEngine;

namespace OffersFeature.View
{
    public interface IOfferRewardView
    {
        Transform Transform { get; }
        
        void SetupView(Sprite sprite, string rewardNumber);
        void SetActive(bool isActive);
    }
}