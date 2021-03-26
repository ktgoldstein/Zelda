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

    public enum UsableItemTypes
    {
        BlueCandle,
        BlueRing,
        Bomb,
        BoomerangNormal,
        BoomerangMagic,
        BowWooden,
        BowSilver,
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

    public enum ObjectHeight
    {
        CanWalkOver = 0,
        CanFlyOver = 1,
        Impassable = 2,
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
        public static Vector2 LinkStartingLocation => new Vector2(Scale(6 * 16 + 8 + 16), Scale(4 * 16 + 80));
        public static Vector2 MiniMapLocation => new Vector2(GameWidth / 24, HUDHeight / 4);
        public static Vector2 LevelNameLocation => new Vector2(MiniMapLocation.X, MiniMapLocation.Y - Scale(9));
        public static Vector2 RupeeCountLocation => new Vector2(MiniMapLocation.X + Scale(77), MiniMapLocation.Y + Scale(4));
        public static Vector2 KeyCountLocation => new Vector2(RupeeCountLocation.X, RupeeCountLocation.Y + Scale(17));
        public static Vector2 BombCountLocation => new Vector2(KeyCountLocation.X, KeyCountLocation.Y + Scale(8));
        public static Vector2 BBoxLocation => new Vector2(RupeeCountLocation.X + Scale(36), RupeeCountLocation.Y);
        public static Vector2 BBoxItemLocation => new Vector2(BBoxLocation.X + Scale(5), BBoxLocation.Y + Scale(8));
        public static Vector2 ABoxLocation => new Vector2(BBoxLocation.X + Scale(25), BBoxLocation.Y);
        public static Vector2 ABoxItemLocation => new Vector2(ABoxLocation.X + Scale(5), ABoxLocation.Y + Scale(8));
        public static Vector2 LifeTextLocation => new Vector2(ABoxLocation.X + Scale(30), ABoxLocation.Y);
        public static Vector2 HealthLocation => new Vector2(LifeTextLocation.X, LifeTextLocation.Y + Scale(24));
        public static int InventoryScreenHeight => Scale(120);
        public static Vector2 InventorySelectionBoxLocation => new Vector2(Scale(0), Scale(0));
        public static Vector2 InventoryBoxLocation => new Vector2(InventorySelectionBoxLocation.X + Scale(123), Scale(0));
        public static Vector2 InventoryRingLocation => new Vector2(InventoryBoxLocation.X + Scale(41), InventoryBoxLocation.Y + Scale(24));
        public static Vector2 InventoryBoomerangLocation => new Vector2(InventoryBoxLocation.X + Scale(9), InventoryBoxLocation.Y + Scale(48));
        public static Vector2 InventoryBombLocation => new Vector2(InventoryBoomerangLocation.X + Scale(24), InventoryBoomerangLocation.Y);
        public static Vector2 InventoryBowLocation => new Vector2(InventoryBombLocation.X + Scale(20), InventoryBombLocation.Y);
        public static Vector2 InventoryArrowLocation => new Vector2(InventoryBowLocation.X + Scale(8), InventoryBowLocation.Y);
        public static Vector2 InventoryCandleLocation => new Vector2(InventoryArrowLocation.X + Scale(20), InventoryArrowLocation.Y);
        public static Vector2 InventoryPotionLocation => new Vector2(InventoryBowLocation.X + Scale(4), InventoryBowLocation.Y + Scale(16));
        public static int GameHeight => Scale(240);
        public static int GameWidth => Scale(256);
        public static int HUDHeight => Scale(64);
        public static int TileSize => Scale(16);
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
        public static Vector2 TopSpawnLocation => new Vector2(Scale(6 * 16 + 8 + 16), Scale(16 + 80));
        public static Vector2 BottomSpawnLocation => new Vector2(Scale(6 * 16 + 8 + 16), Scale(7 * 16 + 80));
        public static Vector2 LeftSpawnLocation => new Vector2(Scale(16 + 16), Scale(4 * 16 + 80));
        public static Vector2 RightSpawnLocation => new Vector2(Scale(12 * 16 + 16), Scale(4 * 16 + 80));
        public static Vector2 SecretRoomSpawnLocationIn => new Vector2(Scale(4 * 16), Scale(16 + 80));
        public static Vector2 SecretRoomSpawnLocationOut => new Vector2(Scale(6 * 16 + 16), Scale(4 * 16 + 80));
        public static int AquamentusHP = 6;
        public static int GelHP = 1;
        public static int GoriyaHP = 3;
        public static int KeeseHP = 1;
        public static int StalfosHP = 2;
        public static int WallmasterHP = 2;
        public static int WizardHP = 1000;
    }
}
