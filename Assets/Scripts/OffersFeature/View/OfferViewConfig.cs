using System.Collections.Generic;
using OffersFeature.Model;

namespace OffersFeature.View
{
    public class OfferViewConfig
    {
        public string HeaderText { get; }
        public string DescriptionText { get; }
        public List<OfferReward> Rewards { get; }
        public float Price { get; }
        public float? Discount { get; }
        public string OfferIconName { get; }

        public OfferViewConfig(
            string headerText,
            string descriptionText,
            List<OfferReward> rewards,
            float price,
            float? discount,
            string offerIconName)
        {
            HeaderText = headerText;
            DescriptionText = descriptionText;
            Rewards = rewards;
            Price = price;
            Discount = discount;
            OfferIconName = offerIconName;
        }
    }
}