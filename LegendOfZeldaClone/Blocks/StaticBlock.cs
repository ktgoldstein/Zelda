using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class StaticBlock : IBlock
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
        public bool Alive { get; set; } = true;

        private readonly ISprite sprite;
        private readonly int height;
        private readonly int width;

        public StaticBlock(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight, bool isBombable)
        {
            Location = location;
            this.sprite = sprite;
            this.height = height;
            this.width = width;
            BlockHeight = objectHeight;
            IsBombable = isBombable;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
    }
}
