using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class OrbSwitch : BlockKernel
    {
        public bool WasHit { get; set; } = false;
        private OrbSprite sprite;

        public OrbSwitch(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight)
            : base(location, sprite, height, width, objectHeight, false, false)
        {
            if (sprite is OrbSprite)
            {
                this.sprite = sprite as OrbSprite;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            if (!WasHit)  
                sourceRectangle = new Rectangle(sprite.SourcePosX, sprite.SourcePosY, width, height);
            else
                sourceRectangle = new Rectangle(sprite.SourcePosX - 9, sprite.SourcePosY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(sprite.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Reset() => WasHit = false;
    }
}
