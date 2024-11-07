using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CommonVIew
{
    public class BuyButton : MonoBehaviour
    {
        private const string DiscountFormat = "-{0}%";
        private const string OldPriceFormat = "{0:.##}";
        
        [SerializeField] private TMP_Text _discountPrice;
        [SerializeField] private TMP_Text _oldPrice;
        [SerializeField] private TMP_Text _discount;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _discountImage;
        [SerializeField] private Button _button;
        
        private Action _clickCallback;

        public void Init(Action clickCallback)
        {
            _clickCallback = clickCallback;
            
            _button.onClick.RemoveListener(ClickBuy);
            _button.onClick.AddListener(ClickBuy);
        }

        public void SetupView(float price, float? discount)
        {
            if (discount.HasValue)
            {
                SetDiscountPrice(price, discount.Value);
            }
            else
            {
                SetPrice(price);
            }
        }

        private void SetDiscountPrice(float price, float discount)
        {
            var oldPrice = price / (1 - discount);
            
            _discountPrice.text = price.ToString();
            _oldPrice.text = string.Format(OldPriceFormat, oldPrice);
            
            var discountInt = Mathf.RoundToInt(100 * discount);
            _discount.text = string.Format(DiscountFormat, discountInt);
            _price.gameObject.SetActive(false);
            
            _discountPrice.gameObject.SetActive(true);
            _oldPrice.gameObject.SetActive(true);
            _discountImage.gameObject.SetActive(true);
        }
        
        private void SetPrice(float price)
        {
            _price.text = price.ToString();
            
            _price.gameObject.SetActive(true);
            
            _discountPrice.gameObject.SetActive(false);
            _oldPrice.gameObject.SetActive(false);
            _discountImage.gameObject.SetActive(false);
        }
        
        private void ClickBuy()
        {
            _clickCallback?.Invoke();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
