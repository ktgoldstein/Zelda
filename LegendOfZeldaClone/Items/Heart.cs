using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Heart : IItem
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

        private ISprite heart;
        private readonly int height;
        private readonly int width;

        public Heart(Vector2 location)
        {
            heart = ItemSpriteFactory.Instance.CreateHeart();
            Location = location;
            width = 7;
            height = 8;
            Alive = true;
        }

        public void Update() => heart.Update();
        public void Draw(SpriteBatch spriteBatch) => heart.Draw(spriteBatch, Location);
        public void BeCollected()
        {
            Die();
            new HeartPickupSoundEffect().Play();
        }
        public void Die() => Alive = false;
    }
}
