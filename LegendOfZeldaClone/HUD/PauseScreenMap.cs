using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseScreenMap : IMapRoom
    {
        public ISprite map;

        public PauseMapRoom firstRoom;
        public PauseMapRoom[] roomList;
        public PauseMapRoom currentRoom; //Make private after refactoring
        private int roomIndex;

        //private ISprite link;

        private readonly GameStateMachine game;

        public PauseScreenMap(GameStateMachine game)
        {
            this.game = game;
            map = HUDTextureFactory.Instance.CreatePauseMap();

            roomList = new PauseMapRoom[16];
            InitilizeMapRoomArray();
            roomIndex = 0;
            currentRoom = roomList[15];
            currentRoom.Visited = true;
        }

        public void Update() { /*link.Update();*/ }


        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, LoZHelpers.PauseMapLocation);
            currentRoom.Draw(spriteBatch);

            foreach (PauseMapRoom room in roomList)
                room.Draw(spriteBatch);

            //link.Draw(spriteBatch, LoZHelpers.LinkPauseLocationTrackerMini);
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

            foreach (PauseMapRoom room in roomList)
                room.Visited = false;
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

        public void PlaceRoomOnMap(Direction direction) => currentRoom.placeRoomWhenVisited(direction);
        public void ChangeRoomType()
        {
            FindRoomInArray();
            currentRoom = roomList[roomIndex];
        }
        public void Reset()
        {
            InitilizeMapRoomArray();
            roomIndex = 0;
            currentRoom = roomList[15];
            currentRoom.Visited = true;
        }
        private void addRoomToList(Direction roomPlacement)
        {
            FindRoomInArray();
            currentRoom = roomList[roomIndex];
            if (currentRoom.Visited == true)
                game.MapRooms.Add(firstRoom);
        }

    }
}
