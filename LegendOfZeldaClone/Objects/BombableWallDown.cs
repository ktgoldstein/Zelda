using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Objects
{
    public class BombableWallDown : IObject 
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }

        private ISprite sprite;
        private readonly int height;
        private readonly int width;

        public BombableWallDown(Vector2 location)
        {
            sprite = ObjectSpriteFactory.Instance.CreateWallFaceDown();
            Location = location;
            height = 32;
            width = 32;
            BlockHeight = ObjectHeight.Impassable;
            IsBombable = true;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
    }
}
