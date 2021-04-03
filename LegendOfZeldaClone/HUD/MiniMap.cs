using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class MiniMap : ISprite
    {
        private readonly ISprite map;
        private Vector2 location;
        private readonly GameStateMachine game;

        public MiniMap(Vector2 location, GameStateMachine game)
        {
            this.game = game;
            map = HUDTextureFactory.Instance.CreateMiniMap();
            this.location = location;
        }

        public void Update() {}
        
        
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => map.Draw(spriteBatch, location);
    }
}
