using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseScreenMap : IMapRoom
    {
        public ISprite map;

        public PauseMapRoom roomOnMap;
        public PauseMapRoom[] roomList;
        
        private int roomIndex;

        LinkLocationPauseMap link;

        private readonly GameStateMachine game;

        public PauseScreenMap(GameStateMachine game)
        {
            this.game = game;

            map = HUDTextureFactory.Instance.CreatePauseMap();

            roomList = new PauseMapRoom[16];

            InitilizeMapRoomArray();
            roomIndex = 0;

            roomOnMap = roomList[15];
            roomOnMap.Visited = true;

            link = new LinkLocationPauseMap(LoZHelpers.LinkLocationTrackerPause, game);
        }

        public void Update()
        {
            link.Update();
/*            if (!roomOnMap.Visited)
                ChangeRoomType();*/
            ChangeRoomType();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, LoZHelpers.PauseMapLocation);

            foreach (PauseMapRoom room in roomList)
                room.Draw(spriteBatch);

            link.Draw(spriteBatch);
        }

        public void UpdateLinkMapLocation(Direction direction) => link.moveLinkOnPauseMap(direction);

        public void PlaceRoomOnMap(Direction direction)
        {
            ChangeRoomType();
            roomOnMap = roomList[roomIndex];

            if(!roomOnMap.Visited)
                roomOnMap.placeRoomWhenVisited(direction);

        }
        public void ChangeRoomType()
        {
            FindRoomInArray();
            roomOnMap = roomList[roomIndex];
        }
        private void FindRoomInArray()

        {
            if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight == null)
                roomIndex = 0;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight != null)
                roomIndex = 1;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight == null)
                roomIndex = 2;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight != null)
                roomIndex = 3;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight == null)
                roomIndex = 4;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight != null)
                roomIndex = 5;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight == null)
                roomIndex = 6;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp == null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight != null)
                roomIndex = 7;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight == null)
                roomIndex = 8;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight != null)
                roomIndex = 9;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight == null)
                roomIndex = 10;

            else if (game.CurrentRoom.RoomDown == null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight != null)
                roomIndex = 11;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight == null)
                roomIndex = 12;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft == null && game.CurrentRoom.RoomRight != null)
                roomIndex = 13;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight == null)
                roomIndex = 14;

            else if (game.CurrentRoom.RoomDown != null && game.CurrentRoom.RoomUp != null && game.CurrentRoom.RoomLeft != null && game.CurrentRoom.RoomRight != null)
                roomIndex = 15;
        }

        private void InitilizeMapRoomArray()
        {
            roomList[0] = new PauseMapRoom(PauseMapRoomType.NoRooms);
            roomList[1] = new PauseMapRoom(PauseMapRoomType.RoomR);
            roomList[2] = new PauseMapRoom(PauseMapRoomType.RoomL);
            roomList[3] = new PauseMapRoom(PauseMapRoomType.RoomLR);
            roomList[4] = new PauseMapRoom(PauseMapRoomType.RoomD);
            roomList[5] = new PauseMapRoom(PauseMapRoomType.RoomDR);
            roomList[6] = new PauseMapRoom(PauseMapRoomType.RoomDL);
            roomList[7] = new PauseMapRoom(PauseMapRoomType.RoomDLR);
            roomList[8] = new PauseMapRoom(PauseMapRoomType.RoomU);
            roomList[9] = new PauseMapRoom(PauseMapRoomType.RoomUR);
            roomList[10] = new PauseMapRoom(PauseMapRoomType.RoomUL);
            roomList[11] = new PauseMapRoom(PauseMapRoomType.RoomULR);
            roomList[12] = new PauseMapRoom(PauseMapRoomType.RoomUD);
            roomList[13] = new PauseMapRoom(PauseMapRoomType.RoomUDR);
            roomList[14] = new PauseMapRoom(PauseMapRoomType.RoomUDL);
            roomList[15] = new PauseMapRoom(PauseMapRoomType.AllRooms);
        }
        public void Reset()
        {
            InitilizeMapRoomArray();
            roomIndex = 0;
            roomOnMap = roomList[15];
            roomOnMap.Visited = true;
            link.Reset();
        }

    }
}
