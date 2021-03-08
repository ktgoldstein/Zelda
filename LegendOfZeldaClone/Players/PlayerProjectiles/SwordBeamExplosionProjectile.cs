using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class SwordBeamExplosionProjectile : IPlayerProjectile
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

        private ISprite[] sprites;
        private Vector2 velocity;
        private readonly int width;
        private readonly int height;
        private int lifeSpan;

        public SwordBeamExplosionProjectile(Vector2 startingLocation, Direction direction, int skinSeed)
        {
            Alive = true;
            width = 8;
            height = 16;

            Location = startingLocation;
            lifeSpan = 10;
            sprites = new ISprite[2];
            DirectionBasedSetUp(direction, skinSeed);
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Alive = false;
            Location += velocity;
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Make skins flash every OTHER frame
            int spriteIndex = lifeSpan % sprites.Length * 2;
            spriteIndex = (int)(spriteIndex / 2.0);
            sprites[spriteIndex].Draw(spriteBatch, Location);
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
}
