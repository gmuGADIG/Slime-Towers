namespace SlimeTowers
{
    
    public enum MaterialType
    {
        CRYSTAL_ROD, 
        STURDY_STONE,
        SLIME
    }

    public struct MyMaterial
    {
        public MaterialType materialType;
        public string description;
    }
}