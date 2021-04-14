using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IBlock : IGameObject
    {
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool IsBorder { get; }

        public void DrawAt(SpriteBatch spriteBatch, Vector2 location);
    }
}
