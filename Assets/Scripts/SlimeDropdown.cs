using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlimeDropdown : MonoBehaviour
{
    private TMPro.TMP_Dropdown slimes;
    public GameObject picture;
    public GameObject name;
    public GameObject description;
    TMP_Text descriptionText, nameText;
    public Sprite BlueSlime, IceSlime, FireSlime, ZapSlime;
    
    // Start is called before the first frame update
    void Start()
    {
        slimes = gameObject.GetComponent<TMPro.TMP_Dropdown>();
        nameText = name.GetComponent<TMP_Text>();
        descriptionText = description.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void slimeValueChanged()
    {
        switch (slimes.value)
        {
            case 0:
                picture.GetComponent<Image>().sprite = BlueSlime;
                nameText.text = ("Blue Slime");
                descriptionText.text = ("The Blue Slime is the most common slime variant. They are found in most areas.");
                break;
            case 1:
                picture.GetComponent<Image>().sprite = IceSlime;
                nameText.text = ("Ice Slime");
                descriptionText.text = ("The Ice Slime is the more frigid brother of the Blue Slime. Often found in Icy Caves, they create layers of slimy ice to insulate themselves.");
                break;
            case 2:
                picture.GetComponent<Image>().sprite = FireSlime;
                nameText.text = ("Fire Slime");
                descriptionText.text = ("The Fire Slime took the opposite evolutionary path of the Ice Slime. They dwell in Fire Caves and absorb the surrounding heat for energy.");
                break;
            case 3:
                picture.GetComponent<Image>().sprite = ZapSlime;
                nameText.text = ("Zap Slime");
                descriptionText.text = ("The Zap Slime is slightly different from the other slime types. These slimes are found in isolated areas with a high concentration of plasma.");
                break;
            default:
                picture.GetComponent<Image>().sprite = BlueSlime;
                nameText.text = ("Blue Slime");
                descriptionText.text = ("The Blue Slime is the most common slime variant. They are found in most areas.");
                break;
        }
    }
}
