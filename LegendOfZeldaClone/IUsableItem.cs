using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IUsableItem
    {
        public void Use();
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }

    public class BlueRing : IUsableItem
    {
        LegendOfZeldaDungeon game;

        public BlueRing(LegendOfZeldaDungeon game) 
        {
            this.game = game;
        }

        public void Use()
        {
            IPlayer link = game.Link;
            if(link is LinkPlayer player)
                game.Link = new BlueRingLinkPlayer(game, player);
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location) { }
    }
}
