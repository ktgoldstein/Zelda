using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Goriya : IEnemy
    {
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite goriyaSprite;
        private float speed = 6;
        private Vector2 direction = new Vector2(0, 1);
        private int timer = 0;
        private Boomerang boomerang;
        private readonly int width;
        private readonly int height;

        public Goriya(Vector2 location)
        {
            goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            width = 13;
            height = 16;

            Location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            goriyaSprite.Draw(spritebatch, Location);
            if (boomerang != null)
            {
                boomerang.Draw(spritebatch);
            }
        }

        public void Update()
        {
            goriyaSprite.Update();
            if(boomerang != null)
            {
                boomerang.Update();
            }

            Location += speed * direction;
            if(timer % 20 == 0)
            {
                ThrowBoomerang(direction);
            }
            if (timer == 0)
            {
                direction = Vector2.UnitY;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();

            }
            else if (timer == 20)
            {
                direction = -Vector2.UnitX;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
            }
            else if (timer == 40)
            {
                direction = -Vector2.UnitY;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
            }
            else if (timer == 60)
            {
                direction = Vector2.UnitX;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
            }
            timer++;
            if (timer > 79)
            {
                timer = 0;
            }
        }

        private void ThrowBoomerang(Vector2 direction)
        {
            if(boomerang == null)
            {
                boomerang = new Boomerang(Location, direction, this);
            }
        }

        public Vector2 GetGoriyaLocation()
        {
            return Location;
        }

        public void CatchBoomerang()
        {
            boomerang = null;
        }
    }
}
