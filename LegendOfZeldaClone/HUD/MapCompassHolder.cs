using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class MapCompassHolder
    {
        private readonly ISprite mapCompassHolderSprite;
        private GameStateMachine game;

        public MapCompassHolder(GameStateMachine game)
        {
            this.game = game;
            mapCompassHolderSprite = HUDTextureFactory.Instance.CreateMapCompassHolder();
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mapCompassHolderSprite.Draw(spriteBatch, LoZHelpers.MapCompassHolderLocation);
        }
    }
}
