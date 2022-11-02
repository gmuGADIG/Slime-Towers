using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "GameData/EnemyObject", order = 2)]
public class EnemyObject : ScriptableObject
{
    public string name;
    public int hp;
    public int damage;
    public Sprite sprite;
    public string description;
    
}