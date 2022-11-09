namespace SlimeTowers 
{
    
    public enum MaterialType {
        CRYSTAL_ROD, 
        STURDY_STONE,
        SLIME,
        FIRE_SLIME,
        ICE_SLIME,
        ZAP_SLIME,
        SUPER_SLIME
    }

    public struct MyMaterial {
        public MaterialType materialType;
        public string description;
    }
}