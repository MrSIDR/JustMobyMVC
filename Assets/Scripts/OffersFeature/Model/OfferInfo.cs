using System;
using UnityEngine;

namespace OffersFeature.Model
{
    [Serializable]
    public class OfferInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private float _price;
        [SerializeField] private float _discountPrice;
        [SerializeField] private bool _hasDiscount;

        public string Id => _id;
        public float Price => _price;
        public float DiscountPrice => _discountPrice;
        public bool HasDiscount => _hasDiscount;
    }
}