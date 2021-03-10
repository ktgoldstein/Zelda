using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBlueRing : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;

        public UsableBlueRing(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            IPlayer link = game.Player;
            if (link is LinkPlayer player)
                game.Player = new BlueRingLinkPlayer(game, player);
        }
    }
}
