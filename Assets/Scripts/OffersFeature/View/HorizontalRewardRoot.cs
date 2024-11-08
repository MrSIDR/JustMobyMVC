using UnityEngine;

namespace OffersFeature.View
{
    public class HorizontalRewardRoot : MonoBehaviour
    {
        [SerializeField] private Transform _root;

        public Transform Root => _root;

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}