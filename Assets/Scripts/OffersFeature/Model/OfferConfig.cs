using System;
using System.Collections.Generic;
using UnityEngine;

namespace OffersFeature.Model
{
    [Serializable]
    public class OfferConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private string _headerKey;
        [SerializeField] private string _descriptionKey;
        [SerializeField] private string _offerIconName;
        [SerializeField] private List<OfferReward> _rewards;

        public string Id => _id;
        public string HeaderKey => _headerKey;
        public string DescriptionKey => _descriptionKey;
        public string OfferIconName => _offerIconName;
        public List<OfferReward> Rewards => _rewards;
    }
}