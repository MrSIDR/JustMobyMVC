using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace OffersFeature.Model
{
    [CreateAssetMenu(fileName = "Offers", menuName = "ScriptableObject/Configs/Offers")]
    public class Offers : ScriptableObject
    {
        [FormerlySerializedAs("_offers")] [SerializeField] private List<OfferInfo> _offerInfos;
        [SerializeField] private List<OfferConfig> _offerConfigs;

        public List<OfferInfo> OfferInfos => _offerInfos;
        public List<OfferConfig> OfferConfigs => _offerConfigs;
    }
}
