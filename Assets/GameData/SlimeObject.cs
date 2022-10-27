using UnityEngine;
[CreateAssetMenu(fileName = "Slime", menuName = "GameData/SlimeObject", order = 1)]
public class SlimeObject : ScriptableObject
{
    public string name;
    public int hp;
    public int damage;
    public Sprite sprite;
    public string description;
    
}
