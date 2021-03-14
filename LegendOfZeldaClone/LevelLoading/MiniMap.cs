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
        ISprite miniMap;
        Vector2 location;

        public MiniMap(Vector2 location)
        {
            miniMap = RoomTextureFactory.Instance.createMiniMap();
            this.location = location;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            miniMap.Draw(spriteBatch, location);
        }

    }
}
