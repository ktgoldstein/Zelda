using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsablePotion : IUsableItem
    {
        private readonly GameStateMachine game;

        public UsablePotion(GameStateMachine game)
        {
            this.game = game;
        }

        public void Use(Vector2 location, Direction direction, PlayerInventory playerInventory)
        {
            game.Player.Health = game.Player.MaxHealth;
            playerInventory.heldItems.Remove(UsableItemTypes.LifePotion);
        }
    }
}
