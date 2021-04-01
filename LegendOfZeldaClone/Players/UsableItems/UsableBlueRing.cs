using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBlueRing : IUsableItem
    {
        private readonly GameStateMachine game;

        public UsableBlueRing(GameStateMachine game) => this.game = game;

        public void Use(Vector2 location, Direction direction, PlayerInventory playerInventory)
        {
            IPlayer link = game.Player;
            if (link is LinkPlayer player)
                game.Player = new BlueRingLinkPlayer(game, player);
        }
    }
}
