using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeTowers
{
    public struct Material
    {
        public MaterialType materialType;
        public string description;

        public enum MaterialType
        {
            A, B, C
        }
    }
}