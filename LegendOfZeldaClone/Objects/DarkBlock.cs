using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class DarkBlock : IObject
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

        public DarkBlock(Vector2 location)
        {
            sprite = ObjectSpriteFactory.Instance.CreateDarkBlock();
            Location = location;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.Impassable;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
    }
}