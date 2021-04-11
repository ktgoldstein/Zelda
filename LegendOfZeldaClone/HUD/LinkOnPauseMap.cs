using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LinkOnPauseMap
    {
        private readonly ISprite linkOnMap;
        private Vector2 linkPauseLocation;

        public LinkOnPauseMap(Vector2 location)
        {
            linkOnMap = HUDTextureFactory.Instance.CreateLocationTracker();
            linkPauseLocation = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkOnMap.Draw(spriteBatch, linkPauseLocation);
        }

        public void MoveLinkOnPauseMap(Direction room)
        {
            
            switch (room)
            {
                case Direction.Left:
                    linkPauseLocation.X -= LoZHelpers.RightLeftRoomPauseMapOffset;
                    break;

                case Direction.Right:
                    linkPauseLocation.X += LoZHelpers.RightLeftRoomPauseMapOffset;
                    break;

                case Direction.Down:
                    linkPauseLocation.Y += LoZHelpers.UpDownRoomPauseMapOffset;
                    break;
                case Direction.Up:
                    linkPauseLocation.Y -= LoZHelpers.UpDownRoomPauseMapOffset;
                    break;
            }
        }
        public void Reset()
        {
            this.linkPauseLocation = LoZHelpers.LinkLocationTrackerPause;
        }

    }
}
