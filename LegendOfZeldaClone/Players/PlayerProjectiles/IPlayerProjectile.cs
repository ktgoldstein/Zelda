using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IPlayerProjectile
    {
        public bool Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
