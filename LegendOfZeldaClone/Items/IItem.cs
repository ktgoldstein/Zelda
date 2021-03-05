using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IItem
    {
        public bool Alive { get; set; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
