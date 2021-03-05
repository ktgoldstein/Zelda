using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class SwordBeamProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private readonly int skinSeed;
        private ISprite[] sprites;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;

        public SwordBeamProjectile(Vector2 startingLocation, Direction direction, LegendOfZeldaDungeon game)
        {
            Alive = true;

            this.game = game;
            location = startingLocation;
            lifeSpan = 20;
            sprites = new ISprite[2];
            Random rnd = new Random();
            skinSeed = rnd.Next(2);
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            if (lifeSpan == 0)
            {
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.UpLeft, skinSeed));
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.UpRight, skinSeed));
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.DownLeft, skinSeed));
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.DownRight, skinSeed));
                Alive = false;
            }
            location += velocity;
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Make skins flash every OTHER frame
            int spriteIndex = lifeSpan % sprites.Length * 2;
            spriteIndex = (int)(spriteIndex / 2.0);
            sprites[spriteIndex].Draw(spriteBatch, location);
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
                    break;
                case Direction.Up:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    break;
                case Direction.Left:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    break;
                case Direction.Right:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite((SwordSkinType)(skinSeed + 2));
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    break;
            }
        }
    }
}
