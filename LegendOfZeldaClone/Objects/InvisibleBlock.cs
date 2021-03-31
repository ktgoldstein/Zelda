using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Objects
{
    public class InvisibleBlock : IObject
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
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }

        private readonly int height;
        private int width;

        public InvisibleBlock(Vector2 location, Direction direction)
        {
            Location = location;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.Impassable;
            IsMovable = false;
            IsBombable = false;
            Alive = true;

            DirectionBasedSetUp(direction);
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) { }

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    width += 8;
                    Location -= new Vector2(LoZHelpers.Scale(8), 0);
                    break;
                case Direction.Right:
                    width += 8;
                    break;
                case Direction.None:
                    break;
            }
        }
        public void Die() => IsAlive = false;
    }
}
