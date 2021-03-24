﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class LadderDoor : IDoor
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
        public bool IsAlive { get; set; }
        public Direction DoorDirection{ get; }
        public bool ActiveCamera { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;

        public LadderDoor(LegendOfZeldaDungeon game, Vector2 location)
        {
            this.game = game;
            sprite = ObjectSpriteFactory.Instance.CreateLadder();
            Location = location;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            IsAlive = true;
            DoorDirection = Direction.Down;
            ActiveCamera = false;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.Camera.CameraTransition(Direction.Up);
            //game.CurrentRoom = game.CurrentRoom.RoomUp;
        }
    }
}