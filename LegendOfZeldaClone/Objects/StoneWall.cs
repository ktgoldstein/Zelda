using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class StoneWall : IObject
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

        private ISprite stairs;
        private readonly int height;
        private readonly int width;

        public StoneWall(Vector2 location)
        {
            stairs = ObjectSpriteFactory.Instance.CreateStoneWall();
            Location = location;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.CanFlyOver;
            IsMovable = false;
            IsBombable = false;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            stairs.Draw(spriteBatch, Location);
        }
    }
}