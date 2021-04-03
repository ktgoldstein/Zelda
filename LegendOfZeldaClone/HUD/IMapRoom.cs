using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public interface IMapRoom 
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
       
    }
}
