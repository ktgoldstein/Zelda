
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
    }
}
