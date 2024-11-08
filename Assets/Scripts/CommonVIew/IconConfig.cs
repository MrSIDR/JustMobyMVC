using System.Collections.Generic;
using UnityEngine;

namespace CommonVIew
{
    [CreateAssetMenu(fileName = "IconConfig", menuName = "ScriptableObject/Configs/IconConfig")]
    public class IconConfig : ScriptableObject
    {
        [SerializeField] private List<IconItem> _config;
        
        public List<IconItem> Config => _config;
    }
}