using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{

    public interface IUsableItem
    {
        public void Use(Vector2 location, Direction direction);
    }

    public class UsableWoodenSword : IUsableItem
    {
        private LegendOfZeldaDungeon game;

        public UsableWoodenSword(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            game.LinkProjectilesQueue.Add(new SwordProjectile(location, SwordSkinType.WoodenSword, direction, game));
        }
    }

    public class UsableBow : IUsableItem
    {
        private LegendOfZeldaDungeon game;
        private ArrowSkinType skinType;

        public UsableBow(LegendOfZeldaDungeon game, ArrowSkinType skinType)
        {
            this.game = game;
            this.skinType = skinType;
        }

        public void Use(Vector2 location, Direction direction)
        {
            game.LinkProjectilesQueue.Add(new ArrowProjectile(location, direction, skinType));
        }
    }

    public class UsableBoomerang : IUsableItem
    {
        private LegendOfZeldaDungeon game;
        private BoomerangSkinType skinType;

        public UsableBoomerang(LegendOfZeldaDungeon game, BoomerangSkinType skinType)
        {
            this.game = game;
            this.skinType = skinType;
        }

        public void Use(Vector2 location, Direction direction)
        {
            game.LinkProjectilesQueue.Add(new BoomerangProjectile(location, direction, skinType, game));
        }
    }

    public class UsableBlueCandle : IUsableItem
    {
        private LegendOfZeldaDungeon game;

        public UsableBlueCandle(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            game.LinkProjectilesQueue.Add(new FireProjectile(game, location, direction));
        }
    }

    public class BlueRing : IUsableItem
    {
        private LegendOfZeldaDungeon game;

        public BlueRing(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            IPlayer link = game.Link;
            if (link is LinkPlayer player)
                game.Link = new BlueRingLinkPlayer(game, player);
        }
    }
}
