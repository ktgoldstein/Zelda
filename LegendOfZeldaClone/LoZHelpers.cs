﻿using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public enum Direction
    {
        Down,
        Up,
        Left,
        Right,
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
        public static int GameHeight => Scale(256);
        public static int GameWidth => Scale(512);
        public static int LinkInvincibilityFrames => 24;
        public static int SpriteSizeMultiplier => 2;
        public static int Scale(int original) => original * SpriteSizeMultiplier;
    }
}
