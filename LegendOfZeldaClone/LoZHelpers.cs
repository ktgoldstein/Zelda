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
        PickingUpTriforce,
        Charge,
        Spin
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
        BlueRupeeValue = 5,
        GoldRupeeValue = 100
    }
    public enum ShopPrices
    {
        LifePotionPrice = 50,
        BombPrice = 20
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

        public static Vector2 GetLocationInRoom(Vector2 location)
        {
            Vector2 newLocation = new Vector2(location.X % GameWidth, location.Y % (GameHeight - HUDHeight));
            if (newLocation.X < 0)
                newLocation += Vector2.UnitX * GameWidth;
            if (newLocation.Y < 0)
                newLocation += Vector2.UnitY * (GameHeight - HUDHeight);

            return newLocation;
        }

        public static Vector2 LinkStartingLocation => new Vector2(Scale(6 * 16 + 8 + 16), Scale(3 * 16 + 80));

        public static Vector2 MiniMapLocation => new Vector2(GameWidth / 24, HUDHeight / 3 - Scale(3));
        public static Vector2 HUDMapLinkStartingLocation => MiniMapLocation + new Vector2(Scale(22), Scale(21));
        public static Vector2 TriForceLocation => HUDMapLinkStartingLocation + new Vector2(Scale(8 * 3), -Scale(4 * 4));

        public static Vector2 PauseMapLocation => InventorySelectionBoxLocation + new Vector2(Scale(100), Scale(88));
        public static Vector2 PauseMapRoomLocation => PauseMapLocation + new Vector2(Scale(56), Scale(40));
        public static Vector2 PauseMapTrackerStartingLocation => PauseMapRoomLocation + Scale(2) * Vector2.One;

        public static Vector2 LevelNameLocation => MiniMapLocation + new Vector2(Scale(4), -Scale(9));
        public static Vector2 RupeeCountLocation => MiniMapLocation + new Vector2(Scale(87), Scale(4));
        public static Vector2 KeyCountLocation => RupeeCountLocation + Scale(17) * Vector2.UnitY;
        public static Vector2 BombCountLocation => KeyCountLocation + Scale(8) * Vector2.UnitY;
        public static Vector2 BBoxLocation => RupeeCountLocation + Scale(36) * Vector2.UnitX;
        public static Vector2 BBoxItemLocation => BBoxLocation + new Vector2(Scale(5), Scale(8));
        public static Vector2 ABoxLocation => BBoxLocation + Scale(25) * Vector2.UnitX;
        public static Vector2 ABoxItemLocation => ABoxLocation + new Vector2(Scale(5), Scale(8));
        public static Vector2 LifeTextLocation => ABoxLocation + new Vector2(Scale(30), 0);
        public static Vector2 HealthLocation => LifeTextLocation + new Vector2(0, Scale(24));

        public static int InventoryScreenOffset => Scale(48);
        public static Vector2 InventorySelectionBoxLocation => new Vector2(Scale(0), - GameHeight + InventoryScreenOffset);
        public static Vector2 InventoryBoxLocation => InventorySelectionBoxLocation + new Vector2(Scale(123), 0);
        public static Vector2 InventoryRingLocation => InventoryBoxLocation + new Vector2(Scale(41), Scale(24));
        public static Vector2 InventoryBoomerangLocation => InventoryBoxLocation + new Vector2(Scale(9), Scale(48));
        public static Vector2 InventoryBombLocation => InventoryBoomerangLocation + Scale(24) * Vector2.UnitX;
        public static Vector2 InventoryBowLocation => InventoryBombLocation + new Vector2(Scale(20), 0);
        public static Vector2 InventoryArrowLocation => InventoryBowLocation + new Vector2(Scale(8), 0);
        public static Vector2 InventoryCandleLocation => InventoryArrowLocation + new Vector2(Scale(20), 0);
        public static Vector2 InventoryPotionLocation => InventoryBowLocation + new Vector2(Scale(4), Scale(16));
        public static Vector2 InventorySelectionItemLocation => InventorySelectionBoxLocation + new Vector2(Scale(68), Scale(48));
        public static Vector2 MapCompassHolderLocation => InventorySelectionBoxLocation + new Vector2(Scale(1), Scale(88));
        public static Vector2 InventoryMapItemLocation => MapCompassHolderLocation + new Vector2(Scale(48), Scale(25));
        public static Vector2 InventoryCompassLocation => InventoryMapItemLocation + new Vector2(-Scale(5), Scale(41));
        public static Vector2 CursorLocation => InventoryBoxLocation + new Vector2(Scale(4), Scale(48));
        public static Vector2 BombCursorLocation = CursorLocation + new Vector2(Scale(24), 0);
        public static Vector2 BowAndArrowCursorLocation = CursorLocation + new Vector2(Scale(44), 0);
        public static Vector2 CandleCursorLocation = CursorLocation + new Vector2(Scale(74), 0);
        public static Vector2 PotionCursorLocation = CursorLocation + new Vector2(Scale(49), Scale(16));
        public static Vector2 InventorySelectionBoxItemLocation = InventorySelectionBoxLocation + new Vector2(Scale(69), Scale(49));
        public static int GameHeight => Scale(240);
        public static int GameWidth => Scale(256);
        public static int HUDHeight => Scale(64);
        public static int TileSize => Scale(16);
        public static int HUDMapHorizontalRoomOffset => Scale(8);
        public static int HUDMapVerticalRoomOffset => Scale(4);
        public static int HorizontalPauseMapRoomOffset => Scale(8);
        public static int VerticalPauseMapRoomOffset => Scale(8);
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
        public static int DodongoHP = 30;
        public static int BombPickUpNumber = 4;
        public static List<Type> DropTable = new List<Type>()
        {   typeof(FlashingRupee), typeof(Heart), typeof(FlashingRupee), typeof(BlueRupee), typeof(Heart),
            typeof(Clock), typeof(FlashingRupee), typeof(BlueRupee), typeof(GoldRupee), typeof(BlueRupee)
        };
        public static Random random = new Random();
        public static int LinkDyingFrames => 55;
        public static int FramesBeforeBlackScreenGameOver => LinkDyingFrames - 16; // 39
        public static int FramesBeforeGameOverMessageAppears => LinkDyingFrames + 20; // 75
        public static int LinkPickingUpTriforceFrames => 180;
        public static int FramesBeforeBlackFadeOutEndsGameWon => LinkPickingUpTriforceFrames - 60; // 120
        public static int FramesBeforeBlackFadeOutBeginsGameWon => FramesBeforeBlackFadeOutEndsGameWon - 40; // 80
        public static int FramesBeforeGameWonMessageAppears => FramesBeforeBlackFadeOutEndsGameWon + 20; // 140
        public static int[,] FireballArray = new int[,]
        {
            {1,0,1,0,1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0,1,0,1,0},
        };
    }
}
