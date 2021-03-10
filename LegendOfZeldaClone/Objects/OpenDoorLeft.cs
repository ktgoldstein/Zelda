using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorLeft : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        private ISprite openDoorLeft;
        private readonly int height;
        private readonly int width;

        public OpenDoorLeft(Vector2 location)
        {
            openDoorLeft = ObjectSpriteFactory.Instance.CreateOpenDoorLeft();
            Location = location;
            height = 32;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            openDoorLeft.Draw(spriteBatch, Location);
        }
    }
}