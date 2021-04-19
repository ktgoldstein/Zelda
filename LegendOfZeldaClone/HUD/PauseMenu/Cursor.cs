using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Cursor
    {
        private readonly ISprite cursorSprite;
        private readonly GameStateMachine game;
        private int animationSpeed;
        public Vector2 location { get; set; }

        public Cursor(GameStateMachine game)
        {
            cursorSprite = HUDTextureFactory.Instance.CreateCursor();
            this.game = game;
            animationSpeed = 0;
            location = LoZHelpers.CursorLocation;
        }

        public void Update(Direction direction)
        {
            animationSpeed++;
            if (animationSpeed % 2 == 0)
                cursorSprite.Update();
            if (location == LoZHelpers.CursorLocation)
            {
                switch (direction)
                {
                    case Direction.Right:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.Bomb))
                            location = LoZHelpers.BombCursorLocation;
                        else if (game.Player.Inventory.HasItem(UsableItemTypes.BowWooden) && game.Player.Inventory.HasArrow)
                            location = LoZHelpers.BowAndArrowCursorLocation;
                        else if (game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                            location = LoZHelpers.CandleCursorLocation;
                        break;
                    case Direction.Down:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                            location = LoZHelpers.PotionCursorLocation;
                        break;
                }
            }
            else if (location == LoZHelpers.BombCursorLocation)
            {
                switch (direction)
                {
                    case Direction.Right:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.BowWooden) && game.Player.Inventory.HasArrow)
                            location = LoZHelpers.BowAndArrowCursorLocation;
                        else if (game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                            location = LoZHelpers.CandleCursorLocation;
                        break;
                    case Direction.Down:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                            location = LoZHelpers.PotionCursorLocation;
                        break;
                    case Direction.Left:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                            location = LoZHelpers.CursorLocation;
                        break;
                }
            }
            else if (location == LoZHelpers.BowAndArrowCursorLocation)
            {
                switch (direction)
                {
                    case Direction.Right:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                            location = LoZHelpers.CandleCursorLocation;
                        break;
                    case Direction.Down:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                            location = LoZHelpers.PotionCursorLocation;
                        break;
                    case Direction.Left:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.Bomb))
                            location = LoZHelpers.BombCursorLocation;
                        else if (game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                            location = LoZHelpers.CursorLocation;
                        break;
                }
            }
            else if (location == LoZHelpers.CandleCursorLocation)
            {
                switch (direction)
                {
                    case Direction.Down:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.LifePotion))
                            location = LoZHelpers.PotionCursorLocation;
                        break;
                    case Direction.Left:
                        if (game.Player.Inventory.HasItem(UsableItemTypes.BowWooden) && game.Player.Inventory.HasArrow)
                            location = LoZHelpers.BowAndArrowCursorLocation;
                        else if (game.Player.Inventory.HasItem(UsableItemTypes.Bomb))
                            location = LoZHelpers.BombCursorLocation;
                        else if (game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                            location = LoZHelpers.CursorLocation;
                        break;
                }
            }
            else if (location == LoZHelpers.PotionCursorLocation)
            {
                if (direction == Direction.Up)
                {
                    if (game.Player.Inventory.HasItem(UsableItemTypes.BowWooden) && game.Player.Inventory.HasArrow)
                        location = LoZHelpers.BowAndArrowCursorLocation;
                    else if (game.Player.Inventory.HasItem(UsableItemTypes.BlueCandle))
                        location = LoZHelpers.CandleCursorLocation;
                    else if (game.Player.Inventory.HasItem(UsableItemTypes.Bomb))
                        location = LoZHelpers.BombCursorLocation;
                    else if (game.Player.Inventory.HasItem(UsableItemTypes.BoomerangNormal))
                        location = LoZHelpers.CursorLocation;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            cursorSprite.Draw(spriteBatch, location);
        }
    }
}
