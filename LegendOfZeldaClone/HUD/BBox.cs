﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class BBox : ISprite
    {
        private readonly ISprite bBoxSprite;
        public ISprite CurrItem { get; set; }

        public BBox()
        {
            bBoxSprite = HUDTextureFactory.Instance.CreateBBox();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            bBoxSprite.Draw(spriteBatch, vector);
        }
    }
}
