using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;

using System;

using MaterialType = SlimeTowers.MaterialType;

public class Inventory : MonoBehaviour
{
    public static Dictionary<MaterialType, int> materials;
    public static Inventory inventory;

    private void Awake()
    {
        //Debug.Log("I'm Alive");
        if(inventory == null) {
            inventory = this;
            //Debug.Log("Inventory set");
        } else {
            //Debug.Log("I'm Dead");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        materials = new Dictionary<MaterialType, int>();
        foreach (MaterialType mt in Enum.GetValues(typeof(MaterialType))) {
            materials.Add(mt, 0);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="materialType"></param>
    /// <returns>int with items remaining - if item type doesnt exist we return -1</returns>

    public int MaterialsRemaining(MaterialType materialType)
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
    public bool RemoveType(MaterialType materialType, int count)
    {
        // check if the current material type exists
        int curMatCount = -1;
        if(materials.TryGetValue(materialType, out curMatCount)) {
            // get the current amoooont of the material
            if (curMatCount - count >= 0) {
                materials[materialType]-=count;
                InventoryUI.inventoryUI.UpdateSet(materialType, materials[materialType]);
                return true;
            }
        }
        return false;
    }

    public int AddItem(MaterialType materialType, int count)
    {
        if (materials.ContainsKey(materialType)) {
            materials[materialType] += count;
        } else {
            materials.Add(materialType, count);
        }
        InventoryUI.inventoryUI.UpdateSet(materialType, materials[materialType]);
        return materials[materialType];
    }

    public void logStatus()
    {
        string s = "";
        foreach (MaterialType m in materials.Keys)
        {
            s = s + m.ToString() + ": " + materials[m] + "\n";
        }
        Debug.Log(s);
    }
}
