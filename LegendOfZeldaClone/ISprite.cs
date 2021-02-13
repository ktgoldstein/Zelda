using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ISprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }   
}
