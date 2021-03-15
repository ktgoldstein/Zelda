using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.LevelLoading
{

    public class MiniMap : ISprite
    {
        private ISprite miniMap;
        private Vector2 mapLocation;

        public MiniMap(Vector2 location)
        {
            miniMap = RoomTextureFactory.Instance.CreateMiniMap();
            this.location = location;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            miniMap.Draw(spriteBatch, mapLocation);
        }

    }
}
