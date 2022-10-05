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
    protected Slime_Type slime = Slime_Type.None;
    //Amount of pierce the bullet has
    protected int piercing = 0;
    //whether or not this tower exists
    protected bool exist = false;
    //Spriterenderer of this object
    public SpriteRenderer spriteRenderer;
    //If true allows towers to be destroyed and replaced with the placeholders
    protected bool destroyMode;

    protected Vector2Int position = new Vector2Int(0, 0);

    public void Awake()
    {
        //spriteRenderer.enabled = exist;
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
                GameObject.Find("TowerManager").GetComponent<TowerManager>().setTower(position, destroyMode);
                Destroy(gameObject);
            }
        }
    }

}
