using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class MapCompassHolder
    {
        private readonly ISprite mapCompassHolderSprite;
        private GameStateMachine game;
        private readonly ISprite mapSprite;
        private readonly ISprite compassSprite;

        public MapCompassHolder(GameStateMachine game)
        {
            this.game = game;
            mapCompassHolderSprite = HUDTextureFactory.Instance.CreateMapCompassHolder();
            mapSprite = HUDTextureFactory.Instance.CreateInventoryMap();
            compassSprite = HUDTextureFactory.Instance.CreateInventoryCompass();
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch)
        {
            mapCompassHolderSprite.Draw(spriteBatch, LoZHelpers.MapCompassHolderLocation);
            if (game.Player.Inventory.HasMap)
                mapSprite.Draw(spriteBatch, LoZHelpers.InventoryMapItemLocation);
            if (game.Player.Inventory.HasCompass)
                compassSprite.Draw(spriteBatch, LoZHelpers.InventoryCompassLocation);
        }
    }
}
