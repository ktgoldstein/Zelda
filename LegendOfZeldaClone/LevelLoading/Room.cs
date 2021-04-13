using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;
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

        private List<IBlock> closedDoors = new List<IBlock>();
        private int doorChangeCount = 0;

        public Vector2 Offset = Vector2.Zero;

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
                if (block is MovableRaisedBlock) (block as MovableRaisedBlock).Reset();
            }

            doorChangeCount = 0;
            game.Blocks.AddRange(Blocks);
            game.Enemies.AddRange(Enemies);
            game.Items.AddRange(Items);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (wallType == 1)
                walls.Draw(spritebatch, new Vector2(0 + Offset.X, Offset.Y));

            if (backgroundType == 1)
                tiles.Draw(spritebatch, new Vector2(LoZHelpers.TileSize * 2 + Offset.X,
                    LoZHelpers.TileSize * 2 + Offset.Y));
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
                Offset.X = row[2] * LoZHelpers.GameWidth;
                Offset.Y = row[3] * (LoZHelpers.GameHeight - LoZHelpers.HUDHeight);

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
            Vector2 tileLocation = new Vector2(LoZHelpers.TileSize * (column + 1) + Offset.X, 
                LoZHelpers.TileSize * (row + 1) + Offset.Y);
            if (fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
                tileLocation = new Vector2(LoZHelpers.TileSize * column + Offset.X, 
                    LoZHelpers.TileSize * (row + 1) + Offset.Y);

            Vector2 smallItemLocation = tileLocation + new Vector2(LoZHelpers.TileSize / 4, 0);
            Vector2 doorLocationUp = tileLocation - new Vector2(0, LoZHelpers.TileSize);
            Vector2 doorLocationDown = tileLocation;
            Vector2 doorLocationRight = tileLocation - new Vector2(0, LoZHelpers.TileSize / 2);
            Vector2 doorLocationLeft = tileLocation - new Vector2(LoZHelpers.TileSize, LoZHelpers.TileSize / 2);

            switch (gameObjectID)
            {
                case -3:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.Left, ObjectHeight.Impassable));
                    break;
                case -2:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.Right, ObjectHeight.Impassable));
                    break;
                case -1:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.None, ObjectHeight.Impassable));
                    break;
                case 1:
                    AddIObject(new RaisedBlock(tileLocation));
                    break;
                case 2:
                    AddIObject(new BlueGargoyleStatue(tileLocation));
                    break;
                case 3:
                    AddIObject(new BlueDragonStatue(tileLocation));
                    break;
                case 4:
                    AddIObject(new DarkBlock(tileLocation));
                    break;
                case 5:
                    AddIObject(new DottedBlock(tileLocation));
                    break;
                case 6:
                    AddIObject(new Water(tileLocation));
                    break;
                case 7:
                    AddIObject(new GargoyleStatue(tileLocation));
                    break;
                case 8:
                    AddIObject(new StoneWall(tileLocation));
                    break;
                case 9:
                    AddIObject(new Ladder(tileLocation));
                    break;
                case 10:
                    AddIObject(new OpenDoorUp(game, doorLocationUp));
                    AddIObject(new LockedDoorUp(doorLocationUp));
                    AddIObject(new PressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 11:
                    AddIObject(new OpenDoorDown(game, doorLocationDown));
                    AddIObject(new LockedDoorDown(doorLocationDown));
                    AddIObject(new PressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
                    break;
                case 13:
                    AddIObject(new OpenDoorRight(game, doorLocationRight));
                    AddIObject(new LockedDoorRight(doorLocationRight));
                    AddIObject(new PressurePlate(tileLocation - 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 14:
                    AddIObject(new OpenDoorLeft(game, doorLocationLeft));
                    AddIObject(new LockedDoorLeft(doorLocationLeft));
                    AddIObject(new PressurePlate(tileLocation + 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 15:
                    AddIObject(new OpenDoorUp(game, doorLocationUp));
                    AddIObject(new PressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 16:
                    AddIObject(new OpenDoorDown(game, doorLocationDown));
                    AddIObject(new PressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
                    break;
                case 17:
                    AddIObject(new OpenDoorRight(game, doorLocationRight));
                    AddIObject(new PressurePlate(tileLocation - 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 18:
                    AddIObject(new OpenDoorLeft(game, doorLocationLeft));
                    AddIObject(new PressurePlate(tileLocation + 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 20:
                    AddIObject(new OpenDoorLeft(game, doorLocationLeft));
                    closedDoors.Add(new ClosedDoorLeft(doorLocationLeft));
                    AddIObject(new PressurePlate(tileLocation + 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 21:
                    AddIObject(new OpenDoorRight(game, doorLocationRight));
                    closedDoors.Add(new ClosedDoorRight(doorLocationRight));
                    AddIObject(new PressurePlate(tileLocation - 2 * LoZHelpers.TileSize * Vector2.UnitX, game));
                    break;
                case 23:
                    AddIObject(new WallUp(doorLocationUp));
                    break;
                case 24:
                    AddIObject(new WallDown(doorLocationDown));
                    break;
                case 25:
                    AddIObject(new WallLeft(doorLocationLeft));
                    break;
                case 26:
                    AddIObject(new WallRight(doorLocationRight));
                    break;
                case 27:
                    AddIObject(new TunnelFaceUp(game, doorLocationUp));
                    AddIObject(new BombableWallUp(doorLocationUp));
                    AddIObject(new PressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, 2 * LoZHelpers.TileSize), game));
                    break;
                case 28:
                    AddIObject(new TunnelFaceDown(game, doorLocationDown));
                    AddIObject(new BombableWallDown(doorLocationDown));
                    AddIObject(new PressurePlate(tileLocation + new Vector2(LoZHelpers.TileSize / 2, -2 * LoZHelpers.TileSize), game));
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
                    AddIObject(new DragonStatue(tileLocation));
                    break;
                case 44:
                    AddIObject(new Stairs(game, tileLocation));
                    break;
                case 45:
                    AddIObject(new MovableRaisedBlock(tileLocation));
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
                    AddIObject(new LadderDoor(game, tileLocation));
                    break;
                case 62:
                    AddIObject(new StoneWall(tileLocation));
                    AddIEnemy(new Keese(tileLocation, game));
                    break;
                case 63:
                    AddIObject(new StoneWall(tileLocation));
                    AddIObject(new InvisibleBlock(tileLocation, Direction.None, ObjectHeight.Impassable));
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
