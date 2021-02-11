using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IEnemy
    {
        public void Update();
        public void Draw(SpriteBatch spritebatch);
       
    }
}


     