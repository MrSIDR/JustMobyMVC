using System.Collections.Generic;
using UnityEngine;

namespace CommonVIew
{
    public class IconHelper : IIconHelper
    {
        private readonly IconConfig _config;
        private readonly Dictionary<string, IconItem> _itemMap = new Dictionary<string, IconItem>();

        public IconHelper(IconConfig config)
        {
            _config = config;

            foreach (var iconItem in _config.Config)
            {
                if (!_itemMap.ContainsKey(iconItem.IconName))
                {
                    _itemMap.Add(iconItem.IconName, iconItem);
                }
                else
                {
                    Debug.LogError($"Icon with name {iconItem.IconName} already exist!");
                }
            }
        }
        
        public Sprite GetSprite(string spriteName)
        {
            if (string.IsNullOrEmpty(spriteName))
            {
                Debug.LogError($"{nameof(spriteName)} is null or empty!");
                return null;
            }

            if (!_itemMap.TryGetValue(spriteName, out var iconItem))
            {
                Debug.LogError($"Icon with name {spriteName} doesn't exist!");
                return null;
            }
            
            return iconItem.Sprite;
        }
    }
}