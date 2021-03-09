using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorUp : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        private ISprite openDoorUp;
        private readonly int height;
        private readonly int width;

        public OpenDoorUp(Vector2 location)
        {
            openDoorUp = ObjectSpriteFactory.Instance.CreateOpenDoorUp();
            Location = location;
            height = 16;
            width = 32;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            openDoorUp.Draw(spriteBatch, Location);
        }
    }
}