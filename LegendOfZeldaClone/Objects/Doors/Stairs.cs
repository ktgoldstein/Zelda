﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class Stairs : IDoor
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
        public Vector2 SpawnLocation { get; }
        public Direction DoorDirection { get; }
        public bool ActiveCamera { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private ISprite stairs;
        private readonly int height;
        private readonly int width;

        public Stairs(LegendOfZeldaDungeon game, Vector2 location)
        {
            this.game = game;
            stairs = ObjectSpriteFactory.Instance.CreateStairs();
            Location = location;
            height = 16;
            width = 16;
            SpawnLocation = LoZHelpers.SecretRoomSpawnLocationIn;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            IsAlive = true;
            DoorDirection = Direction.Down;
            ActiveCamera = false;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => stairs.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.CurrentRoom = game.CurrentRoom.RoomDown;
            game.CurrentRoom.LoadRoom();
        }
    }
}
