using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZeldaClone.Enemy
{
    class Aquamentus : IEnemy
    {
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite aquamentusSprite;
        private float speed = 2;
        private int direction = 1;
        private int timer = 0;
        private List<Fireball> fireballs = new List<Fireball>();
        private readonly int width;
        private readonly int height;

        public Aquamentus(Vector2 location)
        {
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
            width = 24;
            height = 32;

            Location = location;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            aquamentusSprite.Draw(spritebatch, Location);
            foreach (Fireball fireball in fireballs)
            {
                fireball.Draw(spritebatch);
            }
        }
        public void Update()
        {
            aquamentusSprite.Update();
            
            foreach (Fireball fireball in fireballs)
            {
                fireball.Update();
            }

            Location += speed * direction * Vector2.UnitY;
            if (Location.Y > 192)
            {
                direction = -1;
            }
            if (Location.Y < 64)
            {
                direction = 1;
            }

            timer++;
            if(timer == 60)
            {
                SpitFireballs();
                timer = 0;
            }
        }

        private void SpitFireballs()
        {
            fireballs.Add(new Fireball(Location, new Vector2(-2, -1)));
            fireballs.Add(new Fireball(Location, new Vector2(-1, 0)));
            fireballs.Add(new Fireball(Location, new Vector2(-2, 1)));
        }
    }
}
