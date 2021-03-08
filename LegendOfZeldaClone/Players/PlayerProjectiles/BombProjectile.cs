using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class BombProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private readonly LegendOfZeldaDungeon game;
        private readonly ISprite sprite;
        private readonly int width;
        private readonly int height;
        private int lifeSpan;

        public BombProjectile(LegendOfZeldaDungeon game, Vector2 startingLocation, Direction direction)
        {
            Alive = true;
            width = 8;
            height = 16;

            this.game = game;
            Location = startingLocation;
            lifeSpan = 40;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombSprite();
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            if (lifeSpan == 0)
            {
                Location -= new Vector2(LoZHelpers.Scale(4), 0);
                Random rnd = new Random();
                int explosionSeed = rnd.Next(2);
                SpawnExplosions(explosionSeed);
                Alive = false;
            }

            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    Location += new Vector2(LoZHelpers.Scale(4), LoZHelpers.Scale(16));
                    break;
                case Direction.Up:
                    Location += new Vector2(LoZHelpers.Scale(4), -LoZHelpers.Scale(16));
                    break;
                case Direction.Left:
                    Location += new Vector2(-LoZHelpers.Scale(8), 0);
                    break;
                case Direction.Right:
                    Location += new Vector2(LoZHelpers.Scale(16), 0);
                    break;
            }
        }

        private void SpawnExplosions(int seed)
        {
            int explosionWidth = 16;
            int explosionHeight = 16;
            game.LinkProjectilesQueue.Add(new BombExplosionProjectile(Location));
            Vector2 topLeft = Location + new Vector2(-LoZHelpers.Scale(explosionWidth / 2), -LoZHelpers.Scale(explosionHeight));
            Vector2 topRight = Location + new Vector2(LoZHelpers.Scale(explosionWidth / 2), -LoZHelpers.Scale(explosionHeight));
            Vector2 middleLeft = Location + new Vector2(-LoZHelpers.Scale(explosionWidth), 0);
            Vector2 middleRight = Location + new Vector2(LoZHelpers.Scale(explosionWidth), 0);
            Vector2 bottomLeft = Location + new Vector2(-LoZHelpers.Scale(explosionWidth / 2), LoZHelpers.Scale(explosionHeight));
            Vector2 bottomRight = Location + new Vector2(LoZHelpers.Scale(explosionWidth / 2), LoZHelpers.Scale(explosionHeight));
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
