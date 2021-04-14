using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlockKernel : IBlock
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public virtual Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool IsBorder { get; }
        public bool Alive { get; set; } = true;

        private readonly ISprite sprite;
        protected int height;
        protected int width;

        public BlockKernel(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight, bool isBombable, bool isBorder)
        {
            Location = location;
            this.sprite = sprite;
            this.height = height;
            this.width = width;
            BlockHeight = objectHeight;
            IsBombable = isBombable;
            IsBorder = isBorder;
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
    }
}
