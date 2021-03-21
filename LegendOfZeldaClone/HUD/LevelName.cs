﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class LevelName : ISprite
    {
        private readonly ISprite LSprite;
        private readonly ISprite ESprite;
        private readonly ISprite VSprite;
        private readonly ISprite DashSprite;
        private readonly ISprite OneSprite;
        private readonly int space1 = 7;
        private readonly int space2 = 8;
        private readonly int dashHeight = 4;

        public LevelName()
        {
            LSprite = HUDTextureFactory.Instance.CreateL();
            ESprite = HUDTextureFactory.Instance.CreateE();
            VSprite = HUDTextureFactory.Instance.CreateV();
            DashSprite = HUDTextureFactory.Instance.CreateDash();
            OneSprite = HUDTextureFactory.Instance.Create1();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            LSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(space1);
            ESprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(space2);
            VSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(space2);
            ESprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(space2);
            LSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(space1);
            vector.Y += LoZHelpers.Scale(dashHeight);
            DashSprite.Draw(spriteBatch, vector);
            vector.Y -= LoZHelpers.Scale(dashHeight);
            vector.X += LoZHelpers.Scale(space2);
            OneSprite.Draw(spriteBatch, vector);
        }
    }
}
