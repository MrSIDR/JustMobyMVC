using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OffersFeature.View
{
    public class OfferRewardView : MonoBehaviour, IOfferRewardView
    {
        [SerializeField] private Image _rewardImage;
        [SerializeField] private TMP_Text _rewarNumber;

        public Transform Transform => transform;

        public void SetupView(Sprite sprite, string rewardNumber)
        {
            _rewardImage.sprite = sprite;
            _rewarNumber.text = rewardNumber;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
