using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MaterialType = SlimeTowers.MaterialType;
public class InventoryUI : MonoBehaviour
{
    private Canvas inventoryMenu;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu = GetComponent<Canvas>();
        inventoryMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            inventoryMenu.enabled = !inventoryMenu.enabled;
        }

        int i = 0;
        foreach(MaterialType m in Inventory.materials.Keys)
        {
            
            GameObject UItext = new GameObject("Text");
            UItext.transform.SetParent(transform);
            RectTransform trans = UItext.AddComponent<RectTransform>();
            trans.anchoredPosition = new Vector2(0, 32 * i);
            Text t = UItext.AddComponent<Text>();
            t.text = m.ToString() + ": " + Inventory.materials[m];
        }

    }
}
