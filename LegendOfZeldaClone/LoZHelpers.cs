using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZeldaClone
{
    public enum GameState
    {
        GameOver,
        GameWon,
        Pause,
        PauseTransition,
        Play,
        ScreenTransition
    }

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
        PickingUpItem,
        Dying,
        PickingUpTriforce
    }

    public enum UsableItemTypes
    {
        BlueCandle,
        BlueRing,
        Bomb,
        BoomerangNormal,
        BoomerangMagic,
        BowWooden,
        BowSilver,
        LifePotion,
        WoodenSword
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
        DamagedThreeDungeonOne = 9,
        DyingLink = 14
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

    public enum ObjectHeight
    {
        CanWalkOver = 0,
        CanFlyOver = 1,
        Impassable = 2
    }
    public enum RupeeValues
    {
        FlashingRupeeValue = 1,
        BlueRupeeValue = 100,
        GoldRupeeValue = 100
    }
    public enum ShopPrices
    {
        LifePotionPrice = 50,
        BombPrice = 10
    }

    public enum PauseMapRoomType
    {
        NoRooms = 0b0000,
        RoomR = 0b0001,
        RoomL = 0b0010,
        RoomLR = 0b0011,
        RoomD = 0b0100,
        RoomDR = 0b0101,
        RoomDL = 0b0110,
        RoomDLR = 0b0111,
        RoomU = 0b1000,
        RoomUR = 0b1001,
        RoomUL = 0b1010,
        RoomULR = 0b1011,
        RoomUD = 0b1100,
        RoomUDR = 0b1101,
        RoomUDL = 0b1110,
        AllRooms = 0b1111
    }

    public static class LoZHelpers
    {
        public static Vector2 DirectionToVector(Direction direction)
        {
            Vector2 vector = Vector2.Zero;
            switch(direction)
            {
                case Direction.Down:
                    vector = Vector2.UnitY;
                    break;
                case Direction.Up:
                    vector = -Vector2.UnitY;
                    break;
                case Direction.Right:
                    vector = Vector2.UnitX;
                    break;
                case Direction.Left:
                    vector = -Vector2.UnitX;
                    break;
                case Direction.UpLeft:
                    vector = new Vector2(-1, -1);
                    break;
                case Direction.UpRight:
                    vector = new Vector2(1, -1);
                    break;
                case Direction.DownLeft:
                    vector = new Vector2(-1, 1);
                    break;
                case Direction.DownRight:
                    vector = new Vector2(1, 1);
                    break;
            }
            vector.Normalize();
            return vector;
        }

        public static Vector2 LinkStartingLocation => new Vector2(Scale(6 * 16 + 8 + 16), Scale(3 * 16 + 80));
        public static Vector2 MiniMapLocation => new Vector2(GameWidth / 24, HUDHeight / 3);
        public static Vector2 LinkLocationTrackerMini => new Vector2(MiniMapLocation.X + Scale(28), HUDHeight - Scale(12));
        public static Vector2 TriForceLocation => new Vector2(LinkLocationTrackerMini.X + Scale(32),  LinkLocationTrackerMini.Y - Scale(21) - 1);

        public static Vector2 MiniMapPauseLocation => new Vector2(InventorySelectionBoxLocation.X, GameHeight - Scale(50));
        public static Vector2 LinkLocationTrackerPause => new Vector2(PauseMapLocation.X + Scale(58), PauseMapLocation.Y + Scale(66));
        public static Vector2 TriForcePauseLocation => new Vector2(LinkLocationTrackerMini.X + Scale(32), LinkLocationTrackerMini.Y - Scale(21) - 1);
        public static Vector2 PauseMapLocation => new Vector2(InventorySelectionBoxLocation.X + Scale(100), InventorySelectionBoxLocation.Y + Scale(88));
        public static Vector2 PauseMapRoomLocation => new Vector2(PauseMapLocation.X + Scale(56), PauseMapLocation.Y + Scale(64));
        public static Vector2 LevelNameLocation => new Vector2(MiniMapLocation.X + Scale(6), MiniMapLocation.Y - Scale(9));
        public static Vector2 RupeeCountLocation => new Vector2(MiniMapLocation.X + Scale(87), MiniMapLocation.Y + Scale(4));
        public static Vector2 KeyCountLocation => new Vector2(RupeeCountLocation.X, RupeeCountLocation.Y + Scale(17));
        public static Vector2 BombCountLocation => new Vector2(KeyCountLocation.X, KeyCountLocation.Y + Scale(8));
        public static Vector2 BBoxLocation => new Vector2(RupeeCountLocation.X + Scale(36), RupeeCountLocation.Y);
        public static Vector2 BBoxItemLocation => new Vector2(BBoxLocation.X + Scale(5), BBoxLocation.Y + Scale(8));
        public static Vector2 ABoxLocation => new Vector2(BBoxLocation.X + Scale(25), BBoxLocation.Y);
        public static Vector2 ABoxItemLocation => new Vector2(ABoxLocation.X + Scale(5), ABoxLocation.Y + Scale(8));
        public static Vector2 LifeTextLocation => new Vector2(ABoxLocation.X + Scale(30), ABoxLocation.Y);
        public static Vector2 HealthLocation => new Vector2(LifeTextLocation.X, LifeTextLocation.Y + Scale(24));
        public static int InventoryScreenHeight => Scale(120);
        public static Vector2 InventorySelectionBoxLocation => new Vector2(Scale(0), - GameHeight + HUDHeight);
        public static Vector2 InventoryBoxLocation => new Vector2(InventorySelectionBoxLocation.X + Scale(123), -GameHeight + HUDHeight);
        public static Vector2 InventoryRingLocation => InventoryBoxLocation + new Vector2(Scale(41), Scale(24));
        public static Vector2 InventoryBoomerangLocation => new Vector2(InventoryBoxLocation.X + Scale(9), InventoryBoxLocation.Y + Scale(48));
        public static Vector2 InventoryBombLocation => new Vector2(InventoryBoomerangLocation.X + Scale(24), InventoryBoomerangLocation.Y);
        public static Vector2 InventoryBowLocation => new Vector2(InventoryBombLocation.X + Scale(20), InventoryBombLocation.Y);
        public static Vector2 InventoryArrowLocation => new Vector2(InventoryBowLocation.X + Scale(8), InventoryBowLocation.Y);
        public static Vector2 InventoryCandleLocation => new Vector2(InventoryArrowLocation.X + Scale(20), InventoryArrowLocation.Y);
        public static Vector2 InventoryPotionLocation => new Vector2(InventoryBowLocation.X + Scale(4), InventoryBowLocation.Y + Scale(16));
        public static Vector2 InventorySelectionItemLocation => new Vector2(InventorySelectionBoxLocation.X + Scale(68), InventorySelectionBoxLocation.Y + Scale(48));
        public static Vector2 MapCompassHolderLocation => new Vector2(InventorySelectionBoxLocation.X + Scale(1), InventorySelectionBoxLocation.Y + Scale(88));
        public static Vector2 InventoryMapItemLocation => new Vector2(MapCompassHolderLocation.X + Scale(48), MapCompassHolderLocation.Y + Scale(25));
        public static Vector2 InventoryCompassLocation => new Vector2(InventoryMapItemLocation.X - Scale(5), InventoryMapItemLocation.Y + Scale(41));
        public static Vector2 CursorLocation => new Vector2(InventoryBoxLocation.X + Scale(4), InventoryBoomerangLocation.Y);
        public static Vector2 BombCursorLocation = new Vector2(CursorLocation.X + Scale(24), CursorLocation.Y);
        public static Vector2 BowAndArrowCursorLocation = new Vector2(CursorLocation.X + Scale(44), CursorLocation.Y);
        public static Vector2 CandleCursorLocation = new Vector2(CursorLocation.X + Scale(74), CursorLocation.Y);
        public static Vector2 PotionCursorLocation = new Vector2(CursorLocation.X + Scale(49), CursorLocation.Y + Scale(16));
        public static Vector2 InventorySelectionBoxItemLocation = InventorySelectionBoxLocation + new Vector2(Scale(69), Scale(49));
        public static int GameHeight => Scale(240);
        public static int GameWidth => Scale(256);
        public static int HUDHeight => Scale(64);
        public static int TileSize => Scale(16);
        public static int RightLeftRoomMiniMapOffset => Scale(10) + 2;
        public static int UpDownRoomMiniMapOffset => Scale(5) + 1;
        public static int RightLeftRoomPauseMapOffset => Scale(8);
        public static int UpDownRoomPauseMapOffset => Scale(8);
        public static int LinkInvincibilityFrames => 24;
        public static int LinkKnockbackFrames => 8;
        public static int SpriteSizeMultiplier => 3;
        public static int Scale(int original) => original * SpriteSizeMultiplier;
        public static Direction FlipDirection(Direction original)
        {
            return (original) switch
            {
                Direction.Down => Direction.Up,
                Direction.Up => Direction.Down,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.UpLeft => Direction.DownRight,
                Direction.UpRight => Direction.DownLeft,
                Direction.DownLeft => Direction.UpRight,
                Direction.DownRight => Direction.UpLeft,
                Direction.None => Direction.None,
                _ => Direction.None
            };
        }
        public static int BlockSpeed => Scale(1);
        public static int AquamentusHP = 6;
        public static int GelHP = 1;
        public static int GoriyaHP = 3;
        public static int KeeseHP = 1;
        public static int StalfosHP = 2;
        public static int WallmasterHP = 2;
        public static int WizardHP = 1000;
        public static int BombPickUpNumber = 4;
        public static List<Type> DropTable = new List<Type>()
        {   typeof(GoldRupee), typeof(Heart), typeof(GoldRupee), typeof(BlueRupee), typeof(Heart),
            typeof(Clock), typeof(GoldRupee), typeof(GoldRupee), typeof(GoldRupee), typeof(BlueRupee)
        };
        public static Random random = new Random();
        public static int LinkDyingFrames => 55;
        public static int FramesBeforeBlackScreenGameOver => LinkDyingFrames - 16; // 39
        public static int FramesBeforeGameOverMessageAppears => LinkDyingFrames + 20; // 75
        public static int LinkPickingUpTriforceFrames => 180;
        public static int FramesBeforeBlackFadeOutEndsGameWon => LinkPickingUpTriforceFrames - 60; // 120
        public static int FramesBeforeBlackFadeOutBeginsGameWon => FramesBeforeBlackFadeOutEndsGameWon - 40; // 80
        public static int FramesBeforeGameWonMessageAppears => FramesBeforeBlackFadeOutEndsGameWon + 20; // 140
    }
}
