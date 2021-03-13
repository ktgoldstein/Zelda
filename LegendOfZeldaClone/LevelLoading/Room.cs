using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;
using LegendOfZeldaClone.Enemy;
using System.Collections;
using System.Linq;

namespace LegendOfZeldaClone.LevelLoading
{

    public class Room
    {
        private readonly Texture2D tiles;
        private readonly Texture2D background;
        private int backgroundType;
        private int wallType;
        private readonly LegendOfZeldaDungeon game;
        private readonly string fileLocation;

        public Room(string fileLocation, LegendOfZeldaDungeon game)
        {
            this.game = game;
            this.fileLocation = fileLocation;
            tiles = RoomTextureFactory.Instance.tiles;
            background = RoomTextureFactory.Instance.background;
            backgroundType = -1;
            wallType = -1;
        }

        public void LoadRoom()
        {
            game.ResetLists();

            List<List<int>> data = ProcessCSV();

            for (int row = 0; row < data.Count; row++)
            {
                for (int column = 0; column < data[row].Count; column++)
                {
                    ProcessEntry(data[row][column], column, row);
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {

            Rectangle sourceRectangle = new Rectangle(522, 11, 256, 176);
            Rectangle destinationRectangle = new Rectangle(0, 192, 256 *3, 176 * 3);

            if(wallType == 1)
                spritebatch.Draw(background, destinationRectangle, sourceRectangle, Color.White);

            sourceRectangle = new Rectangle(2, 192, 192, 112);
            destinationRectangle = new Rectangle(96, 288, LoZHelpers.Scale(192), LoZHelpers.Scale(112));

            if (backgroundType == 1)
                spritebatch.Draw(tiles, destinationRectangle, sourceRectangle, Color.White);
        }

        private List<List<int>> ProcessCSV()
        {
            List<List<int>> data = new List<List<int>>();
            var lines = File.ReadLines(fileLocation);
            bool readBackgroundType = false;
            bool readWallType = false;
            foreach (var line in lines)
            {
                
                if(!readBackgroundType)
                {

                    backgroundType = int.Parse(line);
                    readBackgroundType = true;
                }
                else if (!readWallType)
                {
                    wallType = int.Parse(line);
                    readWallType = true;
                }
                else
                {
                    var splitLine = line.Split(",");
                    var row = Array.ConvertAll(splitLine, s => int.Parse(s));
                    data.Add(new List<int>((row)));
                }
                

            }
            return data;
        }

        private void ProcessEntry(int gameObjectID, int column, int row)
        {
            int width = 16;
            int height = 16;
            Vector2 tileLocation = new Vector2(LoZHelpers.Scale(width * column + 16), LoZHelpers.Scale(height * row + 80));
            if (fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
                tileLocation = new Vector2(LoZHelpers.Scale(width * column), LoZHelpers.Scale(height * row + 80));

            Vector2 smallItemLocation = new Vector2(LoZHelpers.Scale(width * column + 20), LoZHelpers.Scale(height * row + 80));
            Vector2 doorLocationUp = new Vector2(LoZHelpers.Scale(width * column + 16), LoZHelpers.Scale(height * row + 64));
            Vector2 doorLocationDown = new Vector2(LoZHelpers.Scale(width * column + 16), LoZHelpers.Scale(height * row + 80));
            Vector2 doorLocationRight = new Vector2(LoZHelpers.Scale(width * column + 16), LoZHelpers.Scale(height * (row - 1) + 88));
            Vector2 doorLocationLeft = new Vector2(LoZHelpers.Scale(width * column), LoZHelpers.Scale(height * (row - 1) + 88));

            switch (gameObjectID)
            {
                case -3:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.Left));
                    break;
                case -2:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.Right));
                    break;
                case -1:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.None));
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
                    AddIObject(new OpenDoorUp(doorLocationUp));
                    AddIObject(new LockedDoorUp(doorLocationUp));
                    break;
                case 11:
                    AddIObject(new OpenDoorDown(doorLocationDown));
                    AddIObject(new LockedDoorDown(doorLocationDown));
                    break;
                case 13:
                    AddIObject(new OpenDoorRight(doorLocationRight));
                    AddIObject(new LockedDoorRight(doorLocationRight));
                    break;
                case 14:
                    AddIObject(new OpenDoorLeft(doorLocationLeft));
                    AddIObject(new LockedDoorLeft(doorLocationLeft));
                    break;
                case 15:
                    AddIObject(new OpenDoorUp(doorLocationUp));
                    break;
                case 16:
                    AddIObject(new OpenDoorDown(doorLocationDown));
                    break;
                case 17:
                    AddIObject(new OpenDoorRight(doorLocationRight));
                    break;
                case 18:
                    AddIObject(new OpenDoorLeft(doorLocationLeft));
                    break;
                case 20:
                    AddIObject(new OpenDoorLeft(doorLocationLeft));
                    AddIObject(new ClosedDoorLeft(doorLocationLeft));
                    break;
                case 21:
                    AddIObject(new OpenDoorRight(doorLocationRight));
                    AddIObject(new ClosedDoorRight(doorLocationRight));
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
                    AddIObject(new TunnelFaceUp(doorLocationUp));
                    AddIObject(new BombableWallUp(doorLocationUp));
                    break;
                case 28:
                    AddIObject(new TunnelFaceDown(doorLocationDown));
                    AddIObject(new BombableWallDown(doorLocationDown));
                    break;
                case 29:
                    AddIEnemy(new Keese(tileLocation));
                    break;
                case 30:
                    AddIEnemy(new Stalfos(tileLocation));
                    break;
                case 31:
                    AddIEnemy(new Wallmaster(tileLocation));
                    break;
                case 32:
                    AddIEnemy(new Goriya(game, tileLocation));
                    break;
                case 33:
                    AddIEnemy(new Gel(tileLocation));
                    break;
                case 34:
                    AddIEnemy(new Aquamentus(game, tileLocation));
                    break;
                case 35:
                    AddIEnemy(new BladeTrap(tileLocation));
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
                    AddIObject(new Stairs(tileLocation));
                    break;
                case 45:
                    AddIObject(new MovableRaisedBlock(tileLocation));
                    break;
                default:
                    break;
            }
        }

        private void AddIEnemy(IEnemy enemy) => game.Enemies.Add(enemy);
        private void AddIItem(IItem item) => game.Items.Add(item);
        private void AddIObject(IObject block) => game.Objects.Add(block);
    }
}
