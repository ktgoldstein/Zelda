using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{

    public interface IUsableItem
    {
        public void Use(Direction direction);
    }

    public class WoodenSword : IUsableItem
    {
        private LegendOfZeldaDungeon game;

        public WoodenSword(LegendOfZeldaDungeon game)
        {
            this.game = game;
        }

        public void Use(Direction direction)
        {
            
        }
    }

    public class BlueRing : IUsableItem
    {
        private LegendOfZeldaDungeon game;

        public BlueRing(LegendOfZeldaDungeon game) 
        {
            this.game = game;
        }

        public void Use(Direction direction)
        {
            IPlayer link = game.Link;
            if (link is LinkPlayer player)
                game.Link = new BlueRingLinkPlayer(game, player);
        }
    }
}
