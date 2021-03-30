﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LocationTrackingMini : ISprite
    {
        private readonly ISprite linkMapLocation;
        private Vector2 location;
        private readonly GameStateMachine game;

        public LocationTrackingMini(Vector2 location, GameStateMachine game)
        {
            linkMapLocation = HUDTextureFactory.Instance.CreateLocationTracker();
            this.location = location;
            this.game = game;
        }

        public void Update() { }
        /*{
            int trackRoom = game.RoomListIndex;

            switch (trackRoom)
            {
                case 0:
                    location.X = LoZHelpers.LinkLocationTrackerMini.X;
                    location.Y = LoZHelpers.LinkLocationTrackerMini.Y;
                    break;
                case 1:
                    location.X = LoZHelpers.LinkLocationTrackerMini.X - LoZHelpers.LeftRoomMapOffset - 2;
                    location.Y = LoZHelpers.LinkLocationTrackerMini.Y;
                    break;
                case 2:
                    location.X = LoZHelpers.LinkLocationTrackerMini.X + LoZHelpers.RightRoomMapOffset + 2;
                    location.Y = LoZHelpers.LinkLocationTrackerMini.Y;
                    break;
                case 3:
                    location.X = LoZHelpers.LinkLocationTrackerMini.X;
                    location.Y = LoZHelpers.LinkLocationTrackerMini.Y - LoZHelpers.AboveRoomMapOffset + 2;
                    break;
                case 4:
                    location.X = LoZHelpers.LinkLocationTrackerMini.X;
                    location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 2 * LoZHelpers.AboveRoomMapOffset + 4;
                    break;
                case 5:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X + LoZHelpers.RightRoomMapOffset + 2;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 2 * LoZHelpers.AboveRoomMapOffset + 4;
                    break;
                case 6:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X - LoZHelpers.LeftRoomMapOffset - 2;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 2 * LoZHelpers.AboveRoomMapOffset + 4;
                    break;
                case 7:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X + 2 * (LoZHelpers.RightRoomMapOffset) + 4;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 3 * (LoZHelpers.AboveRoomMapOffset) + 6;
                    break;
                case 8:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X + LoZHelpers.RightRoomMapOffset + 2;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 3 * (LoZHelpers.AboveRoomMapOffset) + 6;
                    break;
                case 9:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 3 * (LoZHelpers.AboveRoomMapOffset) + 6;
                    break;
                case 10:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X - LoZHelpers.LeftRoomMapOffset - 2;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 3 * (LoZHelpers.AboveRoomMapOffset) + 6;
                    break;
                case 11:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X - 2 * LoZHelpers.LeftRoomMapOffset - 4;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 3 * (LoZHelpers.AboveRoomMapOffset) + 6;
                    break;
                case 12:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 4 * (LoZHelpers.AboveRoomMapOffset) + 8;
                    break;
                case 13:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X + 2 * LoZHelpers.RightRoomMapOffset + 4;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 4 * (LoZHelpers.AboveRoomMapOffset) + 8;
                    break;
                case 14:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X + 3 * LoZHelpers.RightRoomMapOffset + 6;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 4 * (LoZHelpers.AboveRoomMapOffset) + 8;
                    break;
                case 15:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 5 * (LoZHelpers.AboveRoomMapOffset) + 10;
                    break;
                case 16:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X - LoZHelpers.LeftRoomMapOffset - 2;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 5 * (LoZHelpers.AboveRoomMapOffset) + 10;
                    break;
                case 17:
                    this.location.X = LoZHelpers.LinkLocationTrackerMini.X - LoZHelpers.LeftRoomMapOffset - 1;
                    this.location.Y = LoZHelpers.LinkLocationTrackerMini.Y - 4 * (LoZHelpers.AboveRoomMapOffset) + 8;
                    break;

            }
        }*/
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => linkMapLocation.Draw(spriteBatch, location);

    }
}
