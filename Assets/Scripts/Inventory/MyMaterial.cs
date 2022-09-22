namespace SlimeTowers
{
    public enum MaterialType
    {
        CRYSTAL_ROD, 
        STURDY_STONE, 
        UNKNOWN
    }

    public struct MyMaterial
    {
        public MaterialType materialType;
        public string description;
    }
}