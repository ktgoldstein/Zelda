using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class BombProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private readonly ISprite sprite;
        private Vector2 location;
        private int lifeSpan;

        public BombProjectile(LegendOfZeldaDungeon game, Vector2 startingLocation, Direction direction)
        {
            Alive = true;

            this.game = game;
            location = startingLocation;
            lifeSpan = 40;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombSprite();
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            if (lifeSpan == 0)
            {
                location -= new Vector2(LoZHelpers.Scale(4), 0);
                Random rnd = new Random();
                int explosionSeed = rnd.Next(2);
                SpawnExplosions(explosionSeed);
                Alive = false;
            }

            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    location += new Vector2(LoZHelpers.Scale(4), LoZHelpers.Scale(16));
                    break;
                case Direction.Up:
                    location += new Vector2(LoZHelpers.Scale(4), -LoZHelpers.Scale(16));
                    break;
                case Direction.Left:
                    location += new Vector2(-LoZHelpers.Scale(8), 0);
                    break;
                case Direction.Right:
                    location += new Vector2(LoZHelpers.Scale(16), 0);
                    break;
            }
        }

        private void SpawnExplosions(int seed)
        {
            int explosionWidth = 16;
            int explosionHeight = 16;
            game.LinkProjectilesQueue.Add(new BombExplosionProjectile(location));
            Vector2 topLeft = location + new Vector2(-LoZHelpers.Scale(explosionWidth / 2), -LoZHelpers.Scale(explosionHeight));
            Vector2 topRight = location + new Vector2(LoZHelpers.Scale(explosionWidth / 2), -LoZHelpers.Scale(explosionHeight));
            Vector2 middleLeft = location + new Vector2(-LoZHelpers.Scale(explosionWidth), 0);
            Vector2 middleRight = location + new Vector2(LoZHelpers.Scale(explosionWidth), 0);
            Vector2 bottomLeft = location + new Vector2(-LoZHelpers.Scale(explosionWidth / 2), LoZHelpers.Scale(explosionHeight));
            Vector2 bottomRight = location + new Vector2(LoZHelpers.Scale(explosionWidth / 2), LoZHelpers.Scale(explosionHeight));
            switch (seed)
            {
                case 0:
                    game.LinkProjectilesQueue.Add(new BombExplosionProjectile(topLeft));
                    game.LinkProjectilesQueue.Add(new BombExplosionProjectile(middleRight));
                    game.LinkProjectilesQueue.Add(new BombExplosionProjectile(bottomRight));
                    break;
                case 1:
                    game.LinkProjectilesQueue.Add(new BombExplosionProjectile(topRight));
                    game.LinkProjectilesQueue.Add(new BombExplosionProjectile(middleLeft));
                    game.LinkProjectilesQueue.Add(new BombExplosionProjectile(bottomLeft));
                    break;
            }
        }
    }
}
