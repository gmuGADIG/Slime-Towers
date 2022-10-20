using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MaterialType = SlimeTowers.MaterialType;
public class InventoryUI : MonoBehaviour
{
    private Canvas inventoryMenu;
    private SortedSet<MaterialType> activeMaterials;
    private List<GameObject> textBoxes;
    public static InventoryUI inventoryUI;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!inventoryUI)
        {
            inventoryUI = this;
        }
        else
        {
            Destroy(gameObject);
        }
        activeMaterials = new SortedSet<MaterialType>();
        textBoxes = new List<GameObject>();
    }

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
    }

    public void UpdateSet(MaterialType m, int count)
    {
        if (count > 0)
        {
            activeMaterials.Add(m);
        } else {
            activeMaterials.Remove(m);
        }
        UpdateObjects();
    }

    private void UpdateObjects()
    {
        float position = 0;
        
        const float OBJ_OFFSET = 16;
        foreach(MaterialType m in activeMaterials)
        {
            GameObject UItext = new GameObject("Text");
            UItext.transform.SetParent(transform);
            RectTransform trans = UItext.AddComponent<RectTransform>();
            trans.pivot = new Vector2(0, 1);
            trans.sizeDelta = new Vector2(200, 100);
            trans.anchoredPosition = new Vector2(0, 0);
            trans.position = new Vector2(0, inventoryMenu.pixelRect.height - position * OBJ_OFFSET);
            Text t = UItext.AddComponent<Text>();
            t.text = m.ToString() + ": " + Inventory.materials[m];
            t.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            position++;
        }
    } 
}
