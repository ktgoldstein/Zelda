using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBomb : IUsableItem
    {
        private readonly GameStateMachine game;

        public UsableBomb(GameStateMachine game) => this.game = game;

        public void Use(Vector2 location, Direction direction, PlayerInventory playerInventory)
        {
            if (playerInventory.BombsHeld > 0)
            {
                playerInventory.BombsHeld--;
                if (playerInventory.BombsHeld == 0) (game.Player as ILinkPlayer).HeldItem = null;
                game.PlayerProjectilesQueue.Add(new BombProjectile(game, location, direction));
                new BombPlacingSoundEffect().Play();
            }
        }
    }
}
