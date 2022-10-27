using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Slime_Type
{
    None,
    Default,
    Fire,
    Ice,
    Zap
}

public class Tower : MonoBehaviour
{
    //HP of tower
    protected int HP = -1;
    //Name of the tower
    public string towerName = "Tower";
    //Amount of damage this tower does
    protected int damage = -1;
    //Type of slime in the tower
    public Slime_Type slime = Slime_Type.None;
    //Amount of pierce the bullet has
    protected int piercing = 0;
    //whether or not this tower exists
    protected bool exist = false;
    //Spriterenderer of this object
    public SpriteRenderer spriteRenderer;
    //If true allows towers to be destroyed and replaced with the placeholders
    protected bool destroyMode;
    //If true allows slimes to be added to towers
    protected bool manageMode;
    //The position in the grid for the tower
    protected Vector2Int position = new Vector2Int(0, 0);

    public GameObject slimeSelector;

    public bool selected = false;

    public void Awake()
    {
        if (slimeSelector != null)
        {
            slimeSelector.SetActive(false);
        }
    }

    public Vector2Int getPosition()
    {
        return position;
    }

    public void setPosition(int x, int y)
    {
        position = new Vector2Int(x, y);
    }

    public void setDestroyMode(bool mode)
    {
        destroyMode = mode;
    }

    public void setManageMode(bool mode)
    {
        manageMode = mode;
        if (!mode)
        {
            selected = false;
            slimeSelector.SetActive(false);
        }
    }

    public void setSlime(string slimeType)
    {
        if (slimeType.Equals("Default"))
        {
            slime = Slime_Type.Default;
        }
        else if (slimeType.Equals("Zap"))
        {
            slime = Slime_Type.Zap;
        }
        else if (slimeType.Equals("Fire"))
        {
            slime = Slime_Type.Fire;
        }
        else if (slimeType.Equals("Ice"))
        {
            slime = Slime_Type.Ice;
        }
        else if (slimeType.Equals("Remove"))
        {
            slime = Slime_Type.None;
        }
    }

    public string getTitle()
    {
        return towerName;
    }

    private void OnMouseEnter()
    {
        //spriteRenderer.color = Color.red;
    }

    private void OnMouseExit()
    {
        //spriteRenderer.color = Color.green;
    }

    private void OnMouseDown()
    {
        if (!manageMode)
        {
            if (towerName.Equals("Tower"))
            {
                if (!destroyMode)
                {
                    GameObject.Find("TowerManager").GetComponent<TowerManager>().setTower(position, destroyMode);
                    Destroy(gameObject);
                }
            }
            else
            {
                if (destroyMode)
                {
                    GameObject towerManager = GameObject.Find("TowerManager");
                    towerManager.GetComponent<TowerManager>().setTower(position, destroyMode);
                    towerManager.GetComponent<TowerManager>().getActiveTowers().Remove(gameObject);
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            slimeSelector.SetActive(selected = !selected);
        }
    }


}
