using UnityEngine;
[CreateAssetMenu(fileName = "Resources", menuName = "GameData/ResourcesObject", order = 3)]
public class ResourcesObject : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public string description;
    
}