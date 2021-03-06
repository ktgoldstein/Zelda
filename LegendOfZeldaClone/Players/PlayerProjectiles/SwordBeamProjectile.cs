using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class SwordBeamProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private readonly GameStateMachine game;
        private readonly ILinkPlayer player;
        private readonly int skinSeed;
        private ISprite[] sprites;
        private Vector2 velocity;
        private int width;
        private int height;
        private int lifeSpan;

        public SwordBeamProjectile(Vector2 startingLocation, Direction direction, GameStateMachine game, ILinkPlayer player)
        {
            Alive = true;

            this.game = game;
            this.player = player;
            Location = startingLocation;
            lifeSpan = 100;
            sprites = new ISprite[2];
            Random rnd = new Random();
            skinSeed = rnd.Next(2);
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            Location += velocity;
            lifeSpan--;
            if (lifeSpan == 0)
                Die();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Make skins flash every OTHER frame
            int spriteIndex = lifeSpan % sprites.Length * 2;
            spriteIndex = (int)(spriteIndex / 2.0);
            sprites[spriteIndex].Draw(spriteBatch, Location);
        }

        private void DirectionBasedSetUp(Direction direction)
        {
            int speed = 6;
            switch (direction)
            {
                case Direction.Down:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordDownSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordDownSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    width = 7;
                    height = 16;
                    break;
                case Direction.Up:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    width = 7;
                    height = 16;
                    break;
                case Direction.Left:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    width = 16;
                    height = 7;
                    break;
                case Direction.Right:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    width = 16;
                    height = 7;
                    break;
            }
        }
        public void SpawnSwordExplosion()
        {
            player.SwordBeamLock += 4;
            game.PlayerProjectilesQueue.Add(new SwordBeamExplosionProjectile(Location, Direction.UpLeft, skinSeed, player));
            game.PlayerProjectilesQueue.Add(new SwordBeamExplosionProjectile(Location, Direction.UpRight, skinSeed, player));
            game.PlayerProjectilesQueue.Add(new SwordBeamExplosionProjectile(Location, Direction.DownLeft, skinSeed, player));
            game.PlayerProjectilesQueue.Add(new SwordBeamExplosionProjectile(Location, Direction.DownRight, skinSeed, player));
        }

        public void Die()
        {
            if (!Alive) return;

            SpawnSwordExplosion();
            Alive = false;
            player.SwordBeamLock--;
        }
    }
}
