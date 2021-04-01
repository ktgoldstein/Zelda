using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBlueCandle : IUsableItem
    {
        private readonly GameStateMachine game;

        public UsableBlueCandle(GameStateMachine game) => this.game = game;

        public void Use(Vector2 location, Direction direction, PlayerInventory playerInventory)
        {
            game.PlayerProjectilesQueue.Add(new FireProjectile(location, direction));
            new BlueCandleSoundEffect().Play();
        }
    }
}
