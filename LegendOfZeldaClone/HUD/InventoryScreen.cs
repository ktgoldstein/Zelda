using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class InventoryScreen
    {
        private readonly ISprite inventoryBox;
        private readonly ISprite inventorySelectBox;

        public InventoryScreen()
        {
            inventoryBox = HUDTextureFactory.Instance.CreateInventoryBox();
            inventorySelectBox = HUDTextureFactory.Instance.CreateInventorySelectionBox();
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {
            inventoryBox.Draw(spritebatch, LoZHelpers.InventoryBoxLocation);
            inventorySelectBox.Draw(spritebatch, LoZHelpers.InventorySelectionBoxLocation);
        }
    }
}
