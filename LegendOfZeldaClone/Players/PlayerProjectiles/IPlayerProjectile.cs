using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IPlayerProjectile
    {
        public bool Alive { get; set; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
