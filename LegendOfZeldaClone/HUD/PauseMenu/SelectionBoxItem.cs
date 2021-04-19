using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class SelectionBoxItem
    {
        private ISprite boomerang;
        private ISprite bomb;
        private ISprite arrow;
        private ISprite potion;
        private ISprite candle;
        private GameStateMachine game;

        public SelectionBoxItem(GameStateMachine game)
        {
            this.game = game;
            boomerang = HUDTextureFactory.Instance.CreateInventoryBoomerang();
            bomb = HUDTextureFactory.Instance.CreateInventoryBomb();
            arrow = HUDTextureFactory.Instance.CreateInventoryArrow();
            potion = HUDTextureFactory.Instance.CreateInventoryPotion();
            candle = HUDTextureFactory.Instance.CreateInventoryCandle();
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (game.InventoryBox.inventoryCursor.location == LoZHelpers.CursorLocation && game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                boomerang.Draw(spriteBatch, LoZHelpers.InventorySelectionItemLocation);
            else if (game.InventoryBox.inventoryCursor.location == LoZHelpers.BombCursorLocation && game.Player.Inventory.BombsHeld > 0)
                bomb.Draw(spriteBatch, LoZHelpers.InventorySelectionItemLocation);
            else if (game.InventoryBox.inventoryCursor.location == LoZHelpers.BowAndArrowCursorLocation && game.Player.Inventory.HasArrow && game.Player.Inventory.HasItem(UsableItemTypes.BowWooden))
                arrow.Draw(spriteBatch, LoZHelpers.InventorySelectionItemLocation);
            else if (game.InventoryBox.inventoryCursor.location == LoZHelpers.CandleCursorLocation && game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                candle.Draw(spriteBatch, LoZHelpers.InventorySelectionItemLocation);
            else if (game.InventoryBox.inventoryCursor.location == LoZHelpers.PotionCursorLocation && game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                potion.Draw(spriteBatch, LoZHelpers.InventorySelectionItemLocation);
        }
    }
}
