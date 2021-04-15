using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendOfZeldaClone.LevelLoading;

namespace LegendOfZeldaClone
{

    public class PauseMap
    {
        public ISprite backgroundSprite;

        public List<PauseMapRoom> pauseMapRooms;
        public PauseMapRoom currentPauseMapRoom;
        
        private readonly PauseMapLink link;
        private readonly GameStateMachine game;
        private readonly Room startingRoom;

        public PauseMap(GameStateMachine game)
        {
            this.game = game;
            startingRoom = game.CurrentRoom;

            backgroundSprite = HUDTextureFactory.Instance.CreatePauseMap();

            currentPauseMapRoom = new PauseMapRoom(startingRoom);
            pauseMapRooms = new List<PauseMapRoom> { currentPauseMapRoom };

            link = new PauseMapLink(startingRoom);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundSprite.Draw(spriteBatch, LoZHelpers.PauseMapLocation);

            foreach (PauseMapRoom room in pauseMapRooms)
                room.Draw(spriteBatch);

            link.Draw(spriteBatch);
        }

        public void MoveRooms(Room targetRoom)
        {
            link.MoveLinkOnPauseMap(targetRoom);
            foreach (PauseMapRoom pauseMapRoom in pauseMapRooms)
            {
                if (pauseMapRoom.Room == targetRoom)
                {
                    currentPauseMapRoom = pauseMapRoom;
                    return;
                }
            }
            currentPauseMapRoom = new PauseMapRoom(game.NextRoom);
            pauseMapRooms.Add(currentPauseMapRoom);
        }               

        public void Reset()
        {
            currentPauseMapRoom = new PauseMapRoom(game.CurrentRoom);
            pauseMapRooms = new List<PauseMapRoom> { currentPauseMapRoom };

            link.Reset();
        }

        public void GoToStart()
        {
            link.Reset();
            foreach (PauseMapRoom pauseMapRoom in pauseMapRooms)
            {
                if (pauseMapRoom.Room == startingRoom)
                {
                    currentPauseMapRoom = pauseMapRoom;
                    return;
                }
            }
        }
    }
}
