using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class BBox
    {
        private readonly ISprite bBoxSprite;
        private Cursor cursor;
        private GameStateMachine game;
        private readonly ISprite boomerangSprite;
        private readonly ISprite bombSprite;
        private readonly ISprite bowSprite;
        private readonly ISprite candleSprite;
        private readonly ISprite potionSprite;
        private bool select;
        private bool boomerang;
        private bool bomb;
        private bool bow;
        private bool candle;
        private bool potion;

        public BBox(GameStateMachine game)
        {
            bBoxSprite = HUDTextureFactory.Instance.CreateBBox();
            boomerangSprite = HUDTextureFactory.Instance.CreateInventoryBoomerang();
            bombSprite = HUDTextureFactory.Instance.CreateInventoryBomb();
            bowSprite = HUDTextureFactory.Instance.CreateInventoryBow();
            candleSprite = HUDTextureFactory.Instance.CreateInventoryCandle();
            potionSprite = HUDTextureFactory.Instance.CreateInventoryPotion();
            this.game = game;
            cursor = game.InventoryBox.inventoryCursor;
            select = false;
            boomerang = false;
            bomb = false;
            bow = false;
            candle = false;
            potion = false;
        }

        public void Update() => select = true;
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            bBoxSprite.Draw(spriteBatch, vector);
            if (select)
            {
                if (cursor.location == LoZHelpers.CursorLocation && game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                {
                    boomerangSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
                    boomerang = true;
                    game.Player.Equip(UsableItemTypes.BoomerangNormal);
                    bomb = false;
                    bow = false;
                    candle = false;
                    potion = false;
                }
                else if (cursor.location == LoZHelpers.BombCursorLocation && game.Player.Inventory.BombsHeld > 0)
                {
                    bombSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
                    bomb = true;
                    game.Player.Equip(UsableItemTypes.Bomb);
                    boomerang = false;
                    bow = false;
                    candle = false;
                    potion = false;
                }
                else if (cursor.location == LoZHelpers.BowAndArrowCursorLocation && game.Player.Inventory.HasArrow && game.Player.Inventory.HasItem(UsableItemTypes.BowWooden))
                {
                    bowSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
                    bow = true;
                    game.Player.Equip(UsableItemTypes.BowWooden);
                    bomb = false;
                    boomerang = false;
                    candle = false;
                    potion = false;
                }
                else if (cursor.location == LoZHelpers.CandleCursorLocation && game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                {
                    candleSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
                    candle = true;
                    game.Player.Equip(UsableItemTypes.BlueCandle);
                    bomb = false;
                    bow = false;
                    boomerang = false;
                    potion = false;
                }
                else if (cursor.location == LoZHelpers.PotionCursorLocation && game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                {
                    potionSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
                    potion = true;
                    game.Player.Equip(UsableItemTypes.LifePotion);
                    bomb = false;
                    bow = false;
                    candle = false;
                    boomerang = false;
                }
                select = false;
            }
            if (game.Player.Inventory.BombsHeld == 0)
                bomb = false;
            if (!game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                potion = false;

            if (boomerang)
                boomerangSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
            else if (bomb)
                bombSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
            else if (bow)
                bowSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
            else if (candle)
                candleSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
            else if (potion)
                potionSprite.Draw(spriteBatch, LoZHelpers.BBoxItemLocation);
        }
    }
}
