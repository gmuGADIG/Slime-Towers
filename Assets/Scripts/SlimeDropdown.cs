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
    public GameObject Description;
    public TMP_Text nameText;
    Sprite IceSlime, FireSlime, ZapSlime, PoisonSlime;
    
    // Start is called before the first frame update
    void Start()
    {
        slimes = gameObject.GetComponent<TMPro.TMP_Dropdown>();
        /*nameText = name.GetComponent<TMP_Text>();
        IceSlime = Resources.Load<Sprite>("Ice Slime_3");
        FireSlime = Resources.Load<Sprite>("Fire Slime");
        ZapSlime = Resources.Load<Sprite>("Zap Slime");
        PoisonSlime = Resources.Load<Sprite>("Super Slime");*/
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(slimes.value);
    }

    public void slimeValueChanged()
    {
        /*switch (slimes.value)
        {
            case 0:
                picture.GetComponent<Image>().sprite = IceSlime;
                break;
            case 1:
                picture.GetComponent<Image>().sprite = FireSlime;
                break;
            case 2:
                picture.GetComponent<Image>().sprite = ZapSlime;
                break;
            case 3:
                picture.GetComponent<Image>().sprite = PoisonSlime;
                break;
            default:
                picture.GetComponent<Image>().sprite = IceSlime;
                break;
        }*/
    }
}
