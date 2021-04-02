using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class MovableRaisedBlock: IObject
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
        public Direction MovedDirection { get; set; } = Direction.None;

        private Vector2 startingLocation;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;

        public MovableRaisedBlock(Vector2 location)
        {
            sprite = ObjectSpriteFactory.Instance.CreateRaisedBlock();
            startingLocation = location;
            Location = startingLocation;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.CanFlyOver;
            IsBombable = false;
            Alive = true;
        }

        public void Update() 
        {
            Vector2 targetLocation = startingLocation;
            switch (MovedDirection)
            {
                case Direction.Down:
                    targetLocation += Height * Vector2.UnitY;
                    break;
                case Direction.Up:
                    targetLocation -= Height * Vector2.UnitY;
                    break;
                case Direction.Left:
                    targetLocation -= Width * Vector2.UnitX;
                    break;
                case Direction.Right:
                    targetLocation += Width * Vector2.UnitX;
                    break;
                case Direction.None:
                    break;
            }
            Vector2 displacement = targetLocation - Location;
            if (displacement.Length() == 0) return;
            displacement.Normalize();
            Location += displacement * LoZHelpers.BlockSpeed;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
        public void Reset()
        {
            MovedDirection = Direction.None;
            Location = startingLocation;
        }
    }
}
