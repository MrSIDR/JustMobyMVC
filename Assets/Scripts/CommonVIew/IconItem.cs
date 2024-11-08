using System;
using UnityEngine;

namespace CommonVIew
{
    [Serializable]
    public class IconItem
    {
        [SerializeField] private string _iconName;
        [SerializeField] private Sprite _sprite;

        public string IconName => _iconName;
        public Sprite Sprite => _sprite;
    }
}