using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class DragonStatue : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }

        private ISprite dragonStatue;
        private readonly int height;
        private readonly int width;

        public DragonStatue(Vector2 location)
        {
            dragonStatue = ObjectSpriteFactory.Instance.CreateDragonStatue();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            dragonStatue.Draw(spriteBatch, Location);
        }
    }
}