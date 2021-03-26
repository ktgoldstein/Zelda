﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorDown : IDoor
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }

        private GameStateMachine game;
        private ISprite openDoorDown;
        private readonly int height;
        private readonly int width;
        private readonly Vector2 hurtBoxOffset = new Vector2(0, LoZHelpers.Scale(16));

        public OpenDoorDown(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            openDoorDown = ObjectSpriteFactory.Instance.CreateOpenDoorDown();
            Location = location;
            height = 16;
            width = 32;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => openDoorDown.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.Camera.CameraTransition(Direction.Down);
            //game.CurrentRoom = game.CurrentRoom.RoomDown;
        }
    }
}