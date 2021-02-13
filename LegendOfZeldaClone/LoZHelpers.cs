namespace LegendOfZeldaClone
{
    public enum LinkSkinType
    {
        Normal = 0,
        BlueRing = 1,
        DamagedOne = 6,
        DamagedTwo = 7,
        DamagedThreeDungeonOne = 9
    }

    public enum LinkSpriteType
    {
        FacingDown = 0,
        FacingUp = 2,
        FacingRight = 4,
        FacingLeft = 6,
        UsingItemDown = 14,
        UsingItemUp = 15,
        UsingItemRight = 16,
        UsingItemLeft = 17,
        PickingUpItem = 18
    }

    public static class LoZHelpers
    {
        public static int SpriteSizeMultiplier => 2;

        public static int Scale(int original) => original * SpriteSizeMultiplier;
    }
}
