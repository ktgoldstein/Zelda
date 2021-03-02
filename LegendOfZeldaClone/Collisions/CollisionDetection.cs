using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Collisions
{
    public static class CollisionDetection
    {
        public static Direction DetectCollisionDirection(Vector2 location1, int width1, int height1, Vector2 location2, int width2, int height2)
        {
            float xOverlap = FindOverlap(location1.X, width1, location2.X, width2);
            float yOverlap = FindOverlap(location1.Y, height1, location2.Y, height2);
            Direction result = Direction.None;

            if (xOverlap > 0 && yOverlap > 0)
            {
                if (xOverlap > yOverlap)
                    result = (location1.Y < location2.Y) ? Direction.Down : Direction.Up;
                else
                    result = (location1.X < location2.X) ? Direction.Right : Direction.Left;
            }

            return result;
        }

        private static float FindOverlap(float start1, int length1, float start2, int length2)
        {
            float difference = start1 - start2;
            float overlap;

            if (difference > 0)
            {
                overlap = length2 - difference;
                if (overlap > length1)
                    overlap = length1;
            }
            else
            {
                overlap = length1 + difference;
                if (overlap > length2)
                    overlap = length2;
            }

            return overlap;
        }
    }
}
