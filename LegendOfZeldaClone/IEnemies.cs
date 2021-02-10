using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IEnemies
    {
        public void Update();
        public void Draw(SpriteBatch spritebatch, Vector2 location);
       
    }
}
