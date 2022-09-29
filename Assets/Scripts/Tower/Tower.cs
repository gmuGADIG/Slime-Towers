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
    int HP = -1;
    //Name of the tower
    string towerName = "Tower";
    //Amount of damage this tower does
    int damage = -1;
    //Type of slime in the tower
    Slime_Type slime = Slime_Type.None;
    //Amount of pierce the bullet has
    int piercing = 0;
    //whether or not this tower exists
    bool exist = false;
    //Spriterenderer of this object
    public SpriteRenderer spriteRenderer;
    //If true allows towers to be destroyed and replaced with the placeholders
    bool destroyMode;

    private Vector2Int position = new Vector2Int(0, 0);

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
        GameObject.Find("TowerManager").GetComponent<TowerManager>().setTower(position);
        Destroy(gameObject);
    }

}
