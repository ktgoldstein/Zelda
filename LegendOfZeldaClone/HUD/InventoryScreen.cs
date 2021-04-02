using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class InventoryScreen
    {
        private readonly ISprite inventoryBox;
        private readonly ISprite inventorySelectBox;
        private readonly ISprite inventoryBomb;
        private readonly ISprite inventoryBow;
        private readonly ISprite inventoryArrow;
        private readonly ISprite inventoryBoomerang;
        private readonly ISprite inventoryCandle;
        private readonly ISprite inventoryPotion;
        private readonly ISprite inventoryRing;
        private GameStateMachine game;
        public Cursor inventoryCursor;

        public InventoryScreen(GameStateMachine game)
        {
            inventoryBox = HUDTextureFactory.Instance.CreateInventoryBox();
            inventorySelectBox = HUDTextureFactory.Instance.CreateInventorySelectionBox();
            inventoryBomb = HUDTextureFactory.Instance.CreateInventoryBomb();
            inventoryBow = HUDTextureFactory.Instance.CreateInventoryBow();
            inventoryArrow = HUDTextureFactory.Instance.CreateInventoryArrow();
            inventoryBoomerang = HUDTextureFactory.Instance.CreateInventoryBoomerang();
            inventoryCandle = HUDTextureFactory.Instance.CreateInventoryCandle();
            inventoryPotion = HUDTextureFactory.Instance.CreateInventoryPotion();
            inventoryRing = HUDTextureFactory.Instance.CreateInventoryRing();
            this.game = game;
            inventoryCursor = new Cursor(game);
        }

        public void Update() => inventoryCursor.Update();
        public void Draw(SpriteBatch spritebatch)
        {
            inventoryBox.Draw(spritebatch, LoZHelpers.InventoryBoxLocation);
            inventorySelectBox.Draw(spritebatch, LoZHelpers.InventorySelectionBoxLocation);
            inventoryCursor.Draw(spritebatch, LoZHelpers.CursorLocation);
            if (game.Player.Inventory.HasItem(UsableItemTypes.Bomb))
                inventoryBomb.Draw(spritebatch, LoZHelpers.InventoryBombLocation);
            if (game.Player.Inventory.HasItem(UsableItemTypes.BowWooden))
                inventoryBow.Draw(spritebatch, LoZHelpers.InventoryBowLocation);
            if (game.Player.Inventory.HasArrow)
                inventoryArrow.Draw(spritebatch, LoZHelpers.InventoryArrowLocation);
            if (game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                inventoryBoomerang.Draw(spritebatch, LoZHelpers.InventoryBoomerangLocation);
            if (game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                inventoryCandle.Draw(spritebatch, LoZHelpers.InventoryCandleLocation);
            if (game.Player.Inventory.HasItem(UsableItemTypes.BlueRing))
                inventoryRing.Draw(spritebatch, LoZHelpers.InventoryRingLocation);
            if (game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                inventoryPotion.Draw(spritebatch, LoZHelpers.InventoryPotionLocation);
        }
    }
}
