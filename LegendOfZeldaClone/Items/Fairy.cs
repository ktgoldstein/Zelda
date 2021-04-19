using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class Fairy : IItem
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

        private ISprite fairy;
        public Vector2 FairyDirection { get; set; }
        private readonly int height;
        private readonly int width;
        private readonly int speed;
        private int timer;
        private readonly Random rnd;

        public Fairy(Vector2 location)
        {
            fairy = ItemSpriteFactory.Instance.CreateFairy();
            Location = location;
            width = 8;
            height = 16;
            FairyDirection = new Vector2(1, 1);
            speed = 2;
            Alive = true;
            timer = 0;
            rnd = new Random();
        }

        public void Update()
        {
            Location += speed * FairyDirection;
            timer++;

            if (timer == 20)
            {
                int switchDirection = rnd.Next(1, 8);
                switch (switchDirection)
                {
                    case 1:
                        FairyDirection = new Vector2(1, 1);
                        break;
                    case 2:
                        FairyDirection = new Vector2(1, 0);
                        break;
                    case 3:
                        FairyDirection = new Vector2(1, -1);
                        break;
                    case 4:
                        FairyDirection = new Vector2(0, 1);
                        break;
                    case 5:
                        FairyDirection = new Vector2(0, -1);
                        break;
                    case 6:
                        FairyDirection = new Vector2(-1, 1);
                        break;
                    case 7:
                        FairyDirection = new Vector2(-1, 0);
                        break;
                    case 8:
                        FairyDirection = new Vector2(-1, -1);
                        break;
                    default:
                        break;
                }
                FairyDirection.Normalize();
                timer = 0;
            }

            fairy.Update();
        }

        public void Draw(SpriteBatch spriteBatch) => fairy.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new FairyPickupSoundEffect().Play();
        }
        public void BuyItem() { }
    }
}
