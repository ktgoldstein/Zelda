using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IItem
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
