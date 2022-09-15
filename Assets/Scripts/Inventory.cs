using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;
using System.Reflection;

using Material = SlimeTowers.Material;

public class Inventory : MonoBehaviour
{
    Dictionary<Material.MaterialType, int> materials;

    public Inventory() => materials = new Dictionary<Material.MaterialType, int>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="materialType"></param>
    /// <returns>int with items remaining - if item type doesnt exist we return -1</returns>

    public int MaterialsRemaining(Material.MaterialType materialType)
    {
        // check if the current material type exists
        int curMatCount = -1;
        if (materials.TryGetValue(materialType, out curMatCount))
            return curMatCount;

        return -1;
    }

    /// <summary>
    /// Remove item of type from inventory one at a time
    /// </summary>
    /// <param name="material"></param>
    /// <returns>bool -> whether or not there are enough materials</returns>
    public int RemoveType(Material.MaterialType materialType, int count)
    {
        // check if the current material type exists
        int curMatCount = -1;
        if(materials.TryGetValue(materialType, out curMatCount)) {
            // get the current amoooont of the material
            if (curMatCount - count >= 0) {
                materials[materialType]--;
                return materials[materialType];
            } else {
                return curMatCount;
            }
        }

        return -1;
    }

    public int AddItem(Material.MaterialType materialType, int count)
    {
        if (materials.ContainsKey(materialType)) {
            materials[materialType] += count;
        } else {
            materials.Add(materialType, count);
        }

        return materials[materialType];
    }
}
