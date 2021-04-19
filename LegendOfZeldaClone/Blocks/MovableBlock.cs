using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class MovableBlock: BlockKernel
    {
        public bool HitTarget { get; set; } = false;
        public Direction MovedDirection { get; set; } = Direction.None;
        public bool Moved => moved;

        private Vector2 startingLocation;
        private Vector2 pastLocation;
        private bool moved = false;

        public MovableBlock(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight)
            : base(location, sprite, height, width, objectHeight, false, false)
        {
            startingLocation = location;
            pastLocation = startingLocation;
        }

        public override void Update()
        {
            if (moved) return;

            Vector2 targetLocation = pastLocation;
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
            if (Location == targetLocation)
            {
                moved = HitTarget;
                MovedDirection = Direction.None;
                pastLocation = Location;
            }
        }

        public void CancelMovement()
        {
            Location = pastLocation;
            MovedDirection = Direction.None;
        }

        public void Reset()
        {
            moved = false;
            MovedDirection = Direction.None;
            Location = startingLocation;
            pastLocation = startingLocation;
        }
    }
}
