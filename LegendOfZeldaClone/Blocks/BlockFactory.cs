using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    class BlockFactory 
    {
        public static BlockFactory Instance { get; } = new BlockFactory();
        private BlockFactory() { }

        //
        // Normal Blocks
        //

        public IBlock CreateBlueDragonStatue(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateBlueDragonStatue(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        public IBlock CreateBlueGargoyleStatue(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateBlueGargoyleStatue(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        public IBlock CreateBombableWallDown(Vector2 location) => new BombableWall(
            location,
            BlockSpriteFactory.Instance.CreateWallFaceDown(),
            32,
            32,
            ObjectHeight.Impassable,
            Direction.Down);

        public IBlock CreateBombableWallUp(Vector2 location) => new BombableWall(
            location,
            BlockSpriteFactory.Instance.CreateWallFaceUp(),
            32,
            32,
            ObjectHeight.Impassable,
            Direction.Up);

        public IBlock CreateClosedDoorDown(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateLockedDoorDown(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateClosedDoorLeft(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateLockedDoorLeft(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateClosedDoorRight(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateLockedDoorRight(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateClosedDoorUp(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateLockedDoorUp(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateDarkBlock(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateDarkBlock(),
            16,
            16,
            ObjectHeight.Impassable,
            false,
            false);

        public IBlock CreateDottedBlock(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateDottedBlock(),
            16,
            16,
            ObjectHeight.CanWalkOver,
            false,
            false);

        public IBlock CreateDragonStatue(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateDragonStatue(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        public IBlock CreateGargoyleStatue(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateGargoyleStatue(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        public IBlock CreateInvisibleBlock(Vector2 location, Direction direction, ObjectHeight objectHeight, bool isBorder)
            => new InvisibleBlock(location,
            null,
            16,
            16,
            objectHeight,
            isBorder,
            direction);

        public IBlock CreateLadder(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateLadder(),
            16,
            16,
            ObjectHeight.CanWalkOver,
            false,
            false);

        public IBlock CreateLockedDoorDown(Vector2 location) => new LockedDoor(
            location,
            BlockSpriteFactory.Instance.CreateKeyDoorDown(),
            32,
            32,
            ObjectHeight.Impassable,
            Direction.Down);

        public IBlock CreateLockedDoorLeft(Vector2 location) => new LockedDoor(
            location,
            BlockSpriteFactory.Instance.CreateKeyDoorLeft(),
            32,
            32,
            ObjectHeight.Impassable,
            Direction.Left);

        public IBlock CreateLockedDoorRight(Vector2 location) => new LockedDoor(
            location,
            BlockSpriteFactory.Instance.CreateKeyDoorRight(),
            32,
            32,
            ObjectHeight.Impassable,
            Direction.Right);

        public IBlock CreateLockedDoorUp(Vector2 location) => new LockedDoor(
            location,
            BlockSpriteFactory.Instance.CreateKeyDoorUp(),
            32,
            32,
            ObjectHeight.Impassable,
            Direction.Up);

        public IBlock CreateMovableBlockGoal(Vector2 location) => new MovableBlockGoal(
            location,
            16,
            16,
            ObjectHeight.CanWalkOver);

        public IBlock CreateMovableRaisedBlock(Vector2 location) => new MovableBlock(
            location,
            BlockSpriteFactory.Instance.CreateRaisedBlock(),
            16,
            16,
            ObjectHeight.CanFlyOver);

        public IBlock CreateEntryPressurePlate(Vector2 location, GameStateMachine game) => new PressurePlate(
            location,
            BlockSpriteFactory.Instance.CreateRaisedBlock(),
            16,
            16,
            ObjectHeight.CanWalkOver,
            game,
            3);

        public IBlock CreateRaisedBlock(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateRaisedBlock(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        public IBlock CreateStoneWall(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateStoneWall(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        public IBlock CreateWallDown(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateWallFaceDown(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateWallLeft(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateWallFaceLeft(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateWallRight(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateWallFaceRight(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateWallUp(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateWallFaceUp(),
            32,
            32,
            ObjectHeight.Impassable,
            false,
            true);

        public IBlock CreateWater(Vector2 location) => new BlockKernel(
            location,
            BlockSpriteFactory.Instance.CreateWater(),
            16,
            16,
            ObjectHeight.CanFlyOver,
            false,
            false);

        //
        // Doors
        //

        public IBlock CreateLadderDoor(Vector2 location, GameStateMachine game) => new LadderDoor(
            location,
            BlockSpriteFactory.Instance.CreateDarkBlock(),
            16,
            16,
            game);

        public IBlock CreateOpenDoorDown(Vector2 location, GameStateMachine game) => new OpenDoorDown(
            location,
            BlockSpriteFactory.Instance.CreateOpenDoorDown(),
            16,
            32,
            game);

        public IBlock CreateOpenDoorLeft(Vector2 location, GameStateMachine game) => new OpenDoorLeft(
            location,
            BlockSpriteFactory.Instance.CreateOpenDoorLeft(),
            32,
            8,
            game);

        public IBlock CreateOpenDoorRight(Vector2 location, GameStateMachine game) => new OpenDoorRight(
            location,
            BlockSpriteFactory.Instance.CreateOpenDoorRight(),
            32,
            8,
            game);

        public IBlock CreateOpenDoorUp(Vector2 location, GameStateMachine game) => new OpenDoorUp(
            location,
            BlockSpriteFactory.Instance.CreateOpenDoorUp(),
            16,
            32,
            game);

        public IBlock CreateStairs(Vector2 location, GameStateMachine game) => new Stairs(
            location,
            BlockSpriteFactory.Instance.CreateStairs(),
            16,
            16,
            game);

        public IBlock CreateTunnelFaceDown(Vector2 location, GameStateMachine game) => new TunnelFaceDown(
            location,
            BlockSpriteFactory.Instance.CreateTunnelFaceDown(),
            16,
            32,
            game);

        public IBlock CreateTunnelFaceUp(Vector2 location, GameStateMachine game) => new TunnelFaceUp(
            location,
            BlockSpriteFactory.Instance.CreateTunnelFaceUp(),
            16,
            32,
            game);
    }
}