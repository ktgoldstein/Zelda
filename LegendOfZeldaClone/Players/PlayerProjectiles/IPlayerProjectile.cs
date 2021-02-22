using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public interface IPlayerProjectile
    {
        public bool Update();
        public void Draw(SpriteBatch spriteBatch);
    }

    public class SwordProjectile : IPlayerProjectile
    {
        private LegendOfZeldaDungeon game;
        private SwordSkinType skinType;
        private ISprite sprite;
        private Direction direction;
        private Vector2 location;
        private int lifeSpan;

        public SwordProjectile(Vector2 startingLocation, SwordSkinType skinType, Direction direction, LegendOfZeldaDungeon game)
        {
            this.game = game;
            this.direction = direction;
            location = startingLocation;
            this.skinType = skinType;
            lifeSpan = 8;
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            switch (lifeSpan)
            {
                case 8:
                    location += DirectedMovement() * LoZHelpers.Scale(2);
                    break;
                case 7:
                    location += DirectedMovement() * LoZHelpers.Scale(9);
                    break;
                case 6:
                case 5:
                    break;
                case 4:
                    location -= DirectedMovement() * LoZHelpers.Scale(4);
                    SpawnSwordBeam();
                    break;
                case 3:
                    break;
                case 2:
                    location -= DirectedMovement() * LoZHelpers.Scale(4);
                    break;
                case 1:
                    break;
            }
            lifeSpan--;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordDownSprite(skinType);
                    location += new Vector2(LoZHelpers.Scale(5), 0);
                    break;
                case Direction.Up:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite(skinType);
                    location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite(skinType);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite(skinType);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
            }
        }

        private Vector2 DirectedMovement()
        {
            return direction switch
            {
                Direction.Down => new Vector2(0, 1),
                Direction.Up => new Vector2(0, -1),
                Direction.Left => new Vector2(-1, 0),
                Direction.Right => new Vector2(1, 0),
                _ => new Vector2(0, 0)
            };
        }

        private void SpawnSwordBeam() => game.LinkProjectilesQueue.Add(new SwordBeamProjectile(location, direction, game));
    }

    public class SwordBeamProjectile : IPlayerProjectile
    {
        private LegendOfZeldaDungeon game;
        private ISprite[] sprites;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;
        private int skinSeed;

        public SwordBeamProjectile(Vector2 startingLocation, Direction direction, LegendOfZeldaDungeon game)
        {
            this.game = game;
            location = startingLocation;
            lifeSpan = 20;
            sprites = new ISprite[2];
            Random rnd = new Random();
            skinSeed = rnd.Next(2);
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            if (lifeSpan == 0)
            {
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.UpLeft, skinSeed));
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.UpRight, skinSeed));
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.DownLeft, skinSeed));
                game.LinkProjectilesQueue.Add(new SwordBeamExplosionProjectile(location, Direction.DownRight, skinSeed));
                return true;
            }
            location += velocity;
            lifeSpan--;
            return false;
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

    public class SwordBeamExplosionProjectile : IPlayerProjectile
    {
        private ISprite[] sprites;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;

        public SwordBeamExplosionProjectile(Vector2 startingLocation, Direction direction, int skinSeed)
        {
            location = startingLocation;
            lifeSpan = 10;
            sprites = new ISprite[2];
            DirectionBasedSetUp(direction, skinSeed);
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            location += velocity;
            lifeSpan--;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Make skins flash every OTHER frame
            int spriteIndex = lifeSpan % sprites.Length * 2;
            spriteIndex = (int)(spriteIndex / 2.0);
            sprites[spriteIndex].Draw(spriteBatch, location);
        }

        private void DirectionBasedSetUp(Direction direction, int skinSeed)
        {
            int speed = 3;
            switch (direction)
            {
                case Direction.DownLeft:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionDownLeftSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionDownLeftSprite((SwordSkinType)(skinSeed + 2));
                    velocity = Vector2.Normalize(new Vector2(-1, 1)) * LoZHelpers.Scale(speed);
                    break;
                case Direction.DownRight:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionDownRightSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionDownRightSprite((SwordSkinType)(skinSeed + 2));
                    velocity = Vector2.Normalize(new Vector2(1, 1)) * LoZHelpers.Scale(speed);
                    break;
                case Direction.UpLeft:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionUpLeftSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionUpLeftSprite((SwordSkinType)(skinSeed + 2));
                    velocity = Vector2.Normalize(new Vector2(-1, -1)) * LoZHelpers.Scale(speed);
                    break;
                case Direction.UpRight:
                    sprites[0] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionUpRightSprite((SwordSkinType)skinSeed);
                    sprites[1] = PlayerProjectileSpriteFactory.Instance.CreateSwordBeamExplosionUpRightSprite((SwordSkinType)(skinSeed + 2));
                    velocity = Vector2.Normalize(new Vector2(1, -1)) * LoZHelpers.Scale(speed);
                    break;
            }
        }
    }

    public class ArrowProjectile : IPlayerProjectile
    {
        private ArrowSkinType skinType;
        private ISprite sprite;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;

        public ArrowProjectile(Vector2 startingLocation, Direction direction, ArrowSkinType skinType)
        {
            this.skinType = skinType;
            location = startingLocation;
            lifeSpan = 20;
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            location += velocity;
            lifeSpan--;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            int speed = 6;
            switch (direction)
            {
                case Direction.Down:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowDownSprite(skinType);
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(5), 0);
                    break;
                case Direction.Up:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowUpSprite(skinType);
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowLeftSprite(skinType);
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowRightSprite(skinType);
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
            }
        }
    }

    public class BoomerangProjectile : IPlayerProjectile
    {
        private LegendOfZeldaDungeon game;
        private ISprite sprite;
        private Vector2 velocity;
        private Vector2 location;
        private int speed;
        private int lifeSpan;

        public BoomerangProjectile(Vector2 startingLocation, Direction direction, BoomerangSkinType skinType, LegendOfZeldaDungeon game)
        {
            this.game = game;
            location = startingLocation;
            speed = 8;
            lifeSpan = 10;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBoomerangSprite(skinType);
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            sprite.Update();
            if (lifeSpan == 0)
            {
                if ((location - game.Link.Location).Length() < 5)
                    return true;

                velocity = game.Link.Location - location;
                velocity.Normalize();
                velocity *= speed;
            }
            else
            {
                lifeSpan--;
            }
            location += velocity;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(5), 0);
                    break;
                case Direction.Up:
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
            }
        }
    }

    public class BombProjectile : IPlayerProjectile
    {
        private LegendOfZeldaDungeon game;
        private ISprite sprite;
        private Vector2 location;
        private int lifeSpan;

        public BombProjectile(LegendOfZeldaDungeon game, Vector2 startingLocation, Direction direction)
        {
            this.game = game;
            location = startingLocation;
            lifeSpan = 40;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombSprite();
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            if (lifeSpan == 0)
            {
                location -= new Vector2(LoZHelpers.Scale(4), 0);
                Random rnd = new Random();
                int explosionSeed = rnd.Next(2);
                SpawnExplosions(explosionSeed);
                return true;
            }

            lifeSpan--;
            return false;
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

    public class BombExplosionProjectile : IPlayerProjectile
    {
        private ISprite sprite;
        private Vector2 location;
        private int maxLifeSpan;
        private int lifeSpan;

        public BombExplosionProjectile(Vector2 startingLocation)
        {
            location = startingLocation;
            maxLifeSpan = 16;
            lifeSpan = maxLifeSpan;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombExplosionSprite();
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            else if (lifeSpan == (int)(maxLifeSpan / 2.0))
                sprite.Update();
            else if (lifeSpan == (int)(maxLifeSpan / 4.0))
                sprite.Update();
            lifeSpan--;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);
    }

    public class FireProjectile : IPlayerProjectile
    {
        private ISprite sprite;
        private Vector2 velocity;
        private Vector2 location;
        private int speed;
        private int lifeSpan;

        public FireProjectile(Vector2 startingLocation, Direction direction)
        {
            location = startingLocation;
            speed = 1;
            lifeSpan = 20;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateFireSprite();
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            sprite.Update();
            if (lifeSpan == 0)
                return true;

            lifeSpan--;
            location += velocity;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    location += new Vector2(0, LoZHelpers.Scale(16));
                    break;
                case Direction.Up:
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    location += new Vector2(0, -LoZHelpers.Scale(16));
                    break;
                case Direction.Left:
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    location += new Vector2(-LoZHelpers.Scale(16), 0);
                    break;
                case Direction.Right:
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    location += new Vector2(LoZHelpers.Scale(16), 0);
                    break;
            }
        }
    }
}
