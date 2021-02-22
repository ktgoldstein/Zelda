using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBlueRing : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;

        public UsableBlueRing(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            IPlayer link = game.Link;
            if (link is LinkPlayer player)
                game.Link = new BlueRingLinkPlayer(game, player);
        }
    }
}
