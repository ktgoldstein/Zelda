﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorLeft : IDoor
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
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }
        public Vector2 SpawnLocation { get; }

        private readonly GameStateMachine game;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;

        public OpenDoorLeft(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            SpawnLocation = LoZHelpers.RightSpawnLocation;
            sprite = ObjectSpriteFactory.Instance.CreateOpenDoorLeft();
            Location = location;
            height = 32;
            width = 16;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.CurrentRoom = game.CurrentRoom.RoomLeft;
            game.CurrentRoom.LoadRoom();
            game.HUDMap.UpdateLinkMapLocation(Direction.Left);
            game.PauseMap.UpdateLinkMapLocation(Direction.Left);
            game.PauseMap.PlaceRoomOnMap(Direction.Left);
        }
        public void Die() { }
    }
}