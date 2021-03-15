using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.LevelLoading
{

    public class Map1 : ISprite
    {
        private ISprite miniMap;
        private Vector2 mapLocation;

        public Map1(Vector2 location)
        {
            miniMap = RoomTextureFactory.Instance.createMiniMap();
            mapLocation = location;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            miniMap.Draw(spriteBatch, mapLocation);
        }

    }
}
