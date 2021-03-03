using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.LevelLoading
{

    public class Room
    {
        public Texture2D tiles;
        public Texture2D exterior;
        private List<List<int>> data;
        String fileLocation;
        private LegendOfZeldaDungeon game;
        public Room(String fileLocation, LegendOfZeldaDungeon game)
        {
            this.game = game;
            this.fileLocation = fileLocation;
            tiles = RoomTextureFactory.Instance.tiles;
            exterior = RoomTextureFactory.Instance.roomExterior;
            
        }
        public void LoadRoom()
        {
            data = new List<List<int>>();
            var lines = File.ReadLines(fileLocation);
            foreach (var line in lines)
            {
                var splitLine = line.Split(",");
                var row = Array.ConvertAll(splitLine, s => int.Parse(s));
                data.Add(new List<int>((row)));
            }
        }

        public void RenderRoom(SpriteBatch spritebatch)
        {
            
            Rectangle sourceRectangle = new Rectangle(0, 0, 240, 160);
            Rectangle destinationRectangle = new Rectangle(0, 0, 240*3, 160*3);
           
            spritebatch.Draw(exterior, destinationRectangle, sourceRectangle, Color.White);
            

            for (int row = 0; row < data.Count; row++)
            {
                for (int column = 0; column < data[row].Count; column++)
                {
                    int width = 16;
                    int height = 16;
                    int sourceRow = data[row][column] / 4;
                    int sourceCol = data[row][column] % 4;
                    sourceRectangle = new Rectangle(width * sourceCol, height * sourceRow, width, height);
                   
                    if (fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
                    {
                        destinationRectangle = new Rectangle((width * column) * 3, (height * row) * 3, width * 3, height * 3);
                    }
                    else
                    {
                        destinationRectangle = new Rectangle((width * column + 8) * 3, (height * row + 8) * 3, width * 3, height * 3);
                    }

                    if(sourceRow != 2 && sourceRow != 5)
                    spritebatch.Draw(tiles, destinationRectangle, sourceRectangle, Color.White);

                    if (sourceRow == 5)
                       game.Objects[22].Draw(spritebatch, new Vector2((width * column + 8) * 3, (height * row + 8) * 3));

                    //if(sourceRow == 0 && sourceCol == 0)
                    //game.Objects[1].Draw(spritebatch, new Vector2((width * column + 24) * 3, (height * row + 24) * 3));
                    //if(sourceCol == 20 && sourceCol == 20)
                    //game.Objects[20].Draw(spritebatch, new Vector2((width * column + 24) * 3, (height * row + 24) * 3));
                }
            }
        }
    }
}
