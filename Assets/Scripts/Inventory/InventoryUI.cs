using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MaterialType = SlimeTowers.MaterialType;
public class InventoryUI : MonoBehaviour
{
    private Canvas inventoryMenu;
    [SerializeField]
    private Transform UIList;
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
        UIList = new GameObject("UIList").transform;
        UIList.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryMenu.enabled = !inventoryMenu.enabled;
        }

        //i'm beginning to debooog
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            Inventory.inventory.RemoveType(MaterialType.STURDY_STONE, 1);
        }*/

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
        int position = 0; //Position indicator, also an iterator for text box objects.
        const float OBJ_OFFSET = 16;//Vertical Offset of each text element
        foreach (MaterialType m in activeMaterials)
        {
            //We reuse our existing boxes by changing their text
            if (position < textBoxes.Count) 
            {
                textBoxes[position].GetComponent<Text>().text = m.ToString() + ": " + Inventory.materials[m];
            } 
            //We add new boxes by
            else 
            {
                GameObject UItext = new GameObject("Text");
                UItext.transform.SetParent(UIList);
                RectTransform trans = UItext.AddComponent<RectTransform>();
                trans.pivot = new Vector2(0, 1);
                trans.sizeDelta = new Vector2(200, 100);
                trans.anchoredPosition = new Vector2(0, 0);
                trans.position = new Vector2(0, inventoryMenu.pixelRect.height - position * OBJ_OFFSET);
                Text t = UItext.AddComponent<Text>();
                t.text = m.ToString() + ": " + Inventory.materials[m];
                t.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                textBoxes.Add(UItext);
            }
            position++;
        }
        //Deleting extra text boxes
        for (int position2=textBoxes.Count-1; position2 >= position; position2--) 
        {
            Destroy(textBoxes[position2]);
            textBoxes.RemoveAt(position2);
        }
    }
}
