using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public enum Direction
    {
        Down,
        Up,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
        None
    }

    public enum LinkStateType
    {
        StandingDown,
        StandingUp,
        StandingLeft,
        StandingRight,
        WalkingDown,
        WalkingUp,
        WalkingLeft,
        WalkingRight,
        UsingItemDown,
        UsingItemUp,
        UsingItemLeft,
        UsingItemRight,
        PickingUpItem
    }

    public enum SwordSkinType
    {
        WoodenSword = 0,
        WhiteSword = 1,
        MagicSword = 2,
        DemonSword = 3
    }

    public enum ArrowSkinType
    {
        Wooden = 0,
        Silver = 1
    }

    public enum BoomerangSkinType
    {
        Normal = 0,
        Magical = 1
    }

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
        public static Vector2 LinkStartingLocation => new Vector2(GameWidth / 2 - 16, GameHeight / 2 - 16);
        public static Vector2 EnemyStartingLocation => new Vector2(400, 120);
        public static Vector2 ObjectStartingLocation => new Vector2(LoZHelpers.GameWidth / 2 + 50, LoZHelpers.GameHeight * 2 / 6);
        public static Vector2 MiniMapLocation => new Vector2(LoZHelpers.GameWidth / 24, 192 / 4);
        public static int GameHeight => Scale(720);
        public static int GameWidth => Scale(768);
        public static int LinkInvincibilityFrames => 24;
        public static int SpriteSizeMultiplier => 3;
        public static int Scale(int original) => original * SpriteSizeMultiplier;
    }
}
