using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Enemy;
using System.Linq;

namespace LegendOfZeldaClone.LevelLoading
{
    public class Room
    {
        public Room RoomUp;
        public Room RoomDown;
        public Room RoomLeft;
        public Room RoomRight;

        public List<IBlock> Blocks = new List<IBlock>();
        public List<IItem> Items = new List<IItem>();
        public List<IEnemy> Enemies = new List<IEnemy>();

        private readonly List<IBlock> closedDoors = new List<IBlock>();
        private int doorChangeCount = 0;

        public Vector2 PixelOffset
        {
            get { return new Vector2(RoomOffset.X * LoZHelpers.GameWidth, RoomOffset.Y * (LoZHelpers.GameHeight - LoZHelpers.HUDHeight)); }
        }
        public Vector2 RoomOffset = Vector2.Zero;

        private readonly ISprite tiles;
        private readonly ISprite walls;
        private readonly GameStateMachine game;
        private readonly string fileLocation;
        private int backgroundType;
        private int wallType;

        public Room(string fileLocation, GameStateMachine game)
        {
            this.game = game;
            this.fileLocation = fileLocation;
            tiles = RoomTextureFactory.Instance.CreateTiles();
            walls = RoomTextureFactory.Instance.CreateWalls();

            List<List<int>> data = ProcessCSV();

            for (int row = 0; row < data.Count; row++)
            {
                for (int column = 0; column < data[row].Count; column++)
                {
                    ProcessEntry(data[row][column], column, row);
                }
            }
        }

        public void CloseDoors()
        {
            if (doorChangeCount == 0)
            {
                game.Blocks.AddRange(closedDoors);
                doorChangeCount++;
            }
        }

        public void OpenDoors()
        {
            if (doorChangeCount == 1)
            {
                game.Blocks = game.Blocks.Except(closedDoors).ToList();
                doorChangeCount++;
            }
        }

        public void LoadRoom()
        {
            game.ResetRoomSpecificLists();
            game.StashBlocks();

            foreach(IBlock block in Blocks)
            {
                if (block is MovableBlock) (block as MovableBlock).Reset();
            }

            doorChangeCount = 0;
            game.Blocks.AddRange(Blocks);
            game.Enemies.AddRange(Enemies);
            game.Items.AddRange(Items);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (wallType == 1)
                walls.Draw(spritebatch, PixelOffset);

            if (backgroundType == 1)
                tiles.Draw(spritebatch, PixelOffset + 2 * LoZHelpers.TileSize * Vector2.One);
        }
        public void DrawAt(SpriteBatch spritebatch, Vector2 offset)
        {
            if (wallType == 1)
                walls.Draw(spritebatch, offset);

            if (backgroundType == 1)
                tiles.Draw(spritebatch, offset + 2 * LoZHelpers.TileSize * Vector2.One);
        }

        public void AddNeighbors(Room roomUp, Room roomDown, Room roomLeft, Room roomRight)
        {
            RoomUp = roomUp;
            RoomDown = roomDown;
            RoomLeft = roomLeft;
            RoomRight = roomRight;
        }

        private List<List<int>> ProcessCSV()
        {

            List<List<int>> data = new List<List<int>>();

            using (StreamReader roomFile = new StreamReader(fileLocation))
            {
                string roomInfo = roomFile.ReadLine();
                var splitLine = roomInfo.Split(",");
                var row = Array.ConvertAll(splitLine, s => int.Parse(s));
                backgroundType = row[0];
                wallType = row[1];
                RoomOffset = new Vector2(row[2], row[3]);

                while ((roomInfo = roomFile.ReadLine()) != null)
                {
                    splitLine = roomInfo.Split(",");
                    row = Array.ConvertAll(splitLine, s => int.Parse(s));
                    data.Add(new List<int>(row));
                }
            }
            return data;
        }

        private void ProcessEntry(int gameObjectID, int column, int row)
        {
            Vector2 tileLocation = new Vector2(LoZHelpers.TileSize * (column + 1) + PixelOffset.X, 
                LoZHelpers.TileSize * (row + 1) + PixelOffset.Y);
            if (fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
                tileLocation = new Vector2(LoZHelpers.TileSize * column + PixelOffset.X, 
                    LoZHelpers.TileSize * (row + 1) + PixelOffset.Y);

            Vector2 smallItemLocation = tileLocation + new Vector2(LoZHelpers.TileSize / 4, 0);
            Vector2 doorLocationUp = tileLocation - new Vector2(0, LoZHelpers.TileSize);
            Vector2 doorLocationDown = tileLocation;
            Vector2 doorLocationRight = tileLocation - new Vector2(0, LoZHelpers.TileSize / 2);
            Vector2 doorLocationLeft = tileLocation - new Vector2(LoZHelpers.TileSize, LoZHelpers.TileSize / 2);

            switch (gameObjectID)
            {
                case -4:
                    AddIObject(BlockFactory.Instance.CreateInvisibleBlock(tileLocation, Direction.None, ObjectHeight.CanFlyOver, false));
                    break;
                case -3:
                    AddIObject(BlockFactory.Instance.CreateInvisibleBlock(tileLocation, Direction.Left, ObjectHeight.Impassable, true));
                    break;
                case -2:
                    AddIObject(BlockFactory.Instance.CreateInvisibleBlock(tileLocation, Direction.Right, ObjectHeight.Impassable, true));
                    break;
                case -1:
                    AddIObject(BlockFactory.Instance.CreateInvisibleBlock(tileLocation, Direction.None, ObjectHeight.Impassable, true));
                    break;
                case 1:
                    AddIObject(BlockFactory.Instance.CreateRaisedBlock(tileLocation));
                    break;
                case 2:
                    AddIObject(BlockFactory.Instance.CreateBlueGargoyleStatue(tileLocation));
                    break;
                case 3:
                    AddIObject(BlockFactory.Instance.CreateBlueDragonStatue(tileLocation));
                    break;
                case 4:
                    AddIObject(BlockFactory.Instance.CreateDarkBlock(tileLocation));
                    break;
                case 5:
                    AddIObject(BlockFactory.Instance.CreateDottedBlock(tileLocation));
                    break;
                case 6:
                    AddIObject(BlockFactory.Instance.CreateWater(tileLocation));
                    break;
                case 7:
                    AddIObject(BlockFactory.Instance.CreateGargoyleStatue(tileLocation));
                    break;
                case 8:
                    AddIObject(BlockFactory.Instance.CreateStoneWall(tileLocation));
                    break;
                case 9:
                    AddIObject(BlockFactory.Instance.CreateLadder(tileLocation));
                    break;
                case 10:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorUp(doorLocationUp, game));
                    AddIObject(BlockFactory.Instance.CreateLockedDoorUp(doorLocationUp));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 11:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorDown(doorLocationDown, game));
                    AddIObject(BlockFactory.Instance.CreateLockedDoorDown(doorLocationDown));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
                    break;
                case 13:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorRight(doorLocationRight, game));
                    AddIObject(BlockFactory.Instance.CreateLockedDoorRight(doorLocationRight));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation - 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 14:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorLeft(doorLocationLeft, game));
                    AddIObject(BlockFactory.Instance.CreateLockedDoorLeft(doorLocationLeft));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 15:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorUp(doorLocationUp, game));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 16:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorDown(doorLocationDown, game));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
                    break;
                case 17:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorRight(doorLocationRight, game));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation - 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 18:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorLeft(doorLocationLeft, game));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 20:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorLeft(doorLocationLeft, game));
                    closedDoors.Add(BlockFactory.Instance.CreateClosedDoorLeft(doorLocationLeft));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 21:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorRight(doorLocationRight, game));
                    closedDoors.Add(BlockFactory.Instance.CreateClosedDoorRight(doorLocationRight));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation - 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 23:
                    AddIObject(BlockFactory.Instance.CreateWallUp(doorLocationUp));
                    break;
                case 24:
                    AddIObject(BlockFactory.Instance.CreateWallDown(doorLocationDown));
                    break;
                case 25:
                    AddIObject(BlockFactory.Instance.CreateWallLeft(doorLocationLeft));
                    break;
                case 26:
                    AddIObject(BlockFactory.Instance.CreateWallRight(doorLocationRight));
                    break;
                case 27:
                    AddIObject(BlockFactory.Instance.CreateTunnelFaceUp(doorLocationUp, game));
                    AddIObject(BlockFactory.Instance.CreateBombableWallUp(doorLocationUp));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 28:
                    AddIObject(BlockFactory.Instance.CreateTunnelFaceDown(doorLocationDown, game));
                    AddIObject(BlockFactory.Instance.CreateBombableWallDown(doorLocationDown));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
                    break;
                case 29:
                    AddIEnemy(new Keese(tileLocation, game));
                    break;
                case 30:
                    AddIEnemy(new Stalfos(game, tileLocation));
                    break;
                case 31:
                    AddIEnemy(new Wallmaster(game, tileLocation));
                    break;
                case 32:
                    AddIEnemy(new Goriya(game, tileLocation));
                    break;
                case 33:
                    AddIEnemy(new Gel(tileLocation, game));
                    break;
                case 34:
                    AddIEnemy(new Aquamentus(game, tileLocation));
                    break;
                case 35:
                    AddIEnemy(new BladeTrap(tileLocation, game.Player));
                    break;
                case 39:
                    AddIItem(new Key(smallItemLocation));
                    break;
                case 40:
                    AddIItem(new Compass(smallItemLocation));
                    break;
                case 41:
                    AddIItem(new Boomerang(smallItemLocation));
                    break;
                case 42:
                    AddIItem(new Map(smallItemLocation));
                    break;
                case 43:
                    AddIObject(BlockFactory.Instance.CreateDragonStatue(tileLocation));
                    break;
                case 44:
                    AddIObject(BlockFactory.Instance.CreateStairs(tileLocation, game));
                    break;
                case 45:
                    AddIObject(BlockFactory.Instance.CreateMovableRaisedBlock(tileLocation));
                    break;
                case 46:
                    Wizard wizard = new Wizard(game, tileLocation);
                    AddIEnemy(wizard);
                    AddIEnemy(new WizardFire(game, tileLocation - new Vector2(LoZHelpers.Scale(3 * 16), 0), wizard));
                    AddIEnemy(new WizardFire(game, tileLocation + new Vector2(LoZHelpers.Scale(3 * 16), 0), wizard));
                    break;
                case 47:
                    AddIItem(new BlueRing(smallItemLocation));
                    break;
                case 48:
                    AddIItem(new Bomb(smallItemLocation));
                    break;
                case 49:
                    AddIItem(new Bow(smallItemLocation));
                    break;
                case 50:
                    AddIItem(new Clock(smallItemLocation));
                    break;
                case 51:
                    AddIItem(new Fairy(smallItemLocation));
                    break;
                case 52:
                    AddIItem(new Heart(smallItemLocation));
                    break;
                case 53:
                    AddIItem(new HeartContainer(smallItemLocation));
                    break;
                case 54:
                    AddIItem(new LifePotion(smallItemLocation));
                    break;
                case 55:
                    AddIItem(new Sword(smallItemLocation));
                    break;
                case 56:
                    AddIItem(new TriForcePiece(tileLocation + new Vector2(LoZHelpers.Scale(3) + LoZHelpers.TileSize / 2, 0)));
                    break;
                case 57:
                    AddIItem(new BlueCandle(smallItemLocation));
                    break;
                case 58:
                    AddIItem(new BlueRupee(smallItemLocation));
                    break;
                case 59:
                    AddIItem(new FlashingRupee(smallItemLocation));
                    break;
                case 60:
                    AddIItem(new Arrow(smallItemLocation));
                    break;
                case 61:
                    AddIObject(BlockFactory.Instance.CreateLadderDoor(tileLocation, game));
                    break;
                case 62:
                    AddIObject(BlockFactory.Instance.CreateStoneWall(tileLocation));
                    AddIEnemy(new Keese(tileLocation, game));
                    break;
                case 63:
                    AddIObject(BlockFactory.Instance.CreateStoneWall(tileLocation));
                    AddIObject(BlockFactory.Instance.CreateInvisibleBlock(tileLocation, Direction.None, ObjectHeight.Impassable, true));
                    break;
                case 64:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorUp(doorLocationUp, game));
                    closedDoors.Add(BlockFactory.Instance.CreateClosedDoorUp(doorLocationUp));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 65:
                    AddIObject(BlockFactory.Instance.CreateOpenDoorDown(doorLocationDown, game));
                    closedDoors.Add(BlockFactory.Instance.CreateClosedDoorDown(doorLocationDown));
                    AddIObject(BlockFactory.Instance.CreateEntryPressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
                    break;
                case 66:
                    AddIObject(BlockFactory.Instance.CreateMovableBlockGoal(tileLocation));
                    break;
                case 67:
                    AddIObject(BlockFactory.Instance.CreateOrbSwitch(tileLocation));
                    break;
                case 68:
                    AddIEnemy(new Dodongo(game, tileLocation));
                    break;
                default:
                    break;
            }
        }

        private void AddIEnemy(IEnemy enemy) => Enemies.Add(enemy);
        private void AddIItem(IItem item) => Items.Add(item);
        private void AddIObject(IBlock block) => Blocks.Add(block);
    }
}
