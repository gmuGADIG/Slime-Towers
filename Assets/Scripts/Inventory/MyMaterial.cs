namespace SlimeTowers 
{
    
    public enum MaterialType {
        CRYSTAL_ROD, 
        STURDY_STONE,
        SLIME,
        FIRE_SLIME,
        ICE_SLIME,
        SLUDGE_SLIME,
        SUPER_SLIME,
        VINE_SLIME,
        ZAP_SLIME
        
    }

    public struct MyMaterial {
        public MaterialType materialType;
        public string description;
    }
}