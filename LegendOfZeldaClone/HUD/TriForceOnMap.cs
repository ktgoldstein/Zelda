using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class TriForceOnMap : ISprite
    {
        private readonly ISprite triForce;
        private Vector2 location;
        private readonly LegendOfZeldaDungeon game;

        public TriForceOnMap(Vector2 location, LegendOfZeldaDungeon game)
        {
            triForce = HUDTextureFactory.Instance.CreateTriForceIndicator();
            this.location = location;
            this.game = game;
        }

        public void Update() => triForce.Update();

        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => triForce.Draw(spriteBatch, location);
    }
}
