﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IPlayer
    {
        public float Speed { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get; }
        public int Width { get; }
        public int Height { get; }
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void ActionA();
        public void ActionB();
        public void Damage(int amount);
        public void Heal(int amount);
        //TODO: requires collision detection
        //public void PickUpItem(IUsableItem item);
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
