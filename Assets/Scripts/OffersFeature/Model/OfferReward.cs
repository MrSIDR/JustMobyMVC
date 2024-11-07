using System;
using UnityEngine;

namespace OffersFeature.Model
{
    [Serializable]
    public class OfferReward
    {
        [SerializeField] private string _itemName;
        [SerializeField] private int _itemCount;

        public string ItemName => _itemName;
        public int ItemCount => _itemCount;
    }
}