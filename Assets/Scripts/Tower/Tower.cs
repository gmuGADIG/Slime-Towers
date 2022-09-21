using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int HP = -1;
    //Name of the tower
    private string name = "Tower";
    //Amount of damage this tower does
    private int damage = -1;
    //Type of slime in the tower
    private Slime_Type slime = Slime_Type.None;
    //Amount of pierce the bullet has
    private int piercing = 0;
    //whether or not this tower exists
    private bool exist = false;
    //Spriterenderer of this object
    public SpriteRenderer spriteRenderer;

    private Vector2 position = new Vector2(0, 0);

    public void Start()
    {
        if (!exist)
        {
            //Sprite disabled here
        }
    }

    public void setPosition(float posX, float posY)
    {


    }

}
