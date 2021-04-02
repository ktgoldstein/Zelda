using LegendOfZeldaClone.Enemies.EnemyTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace LegendOfZeldaClone.Enemies
{
    public abstract class EnemyKernal : IEnemy
    {
        public LegendOfZeldaDungeon game;
        public abstract int AttackStat { get; }
        public abstract int Health { get; set; }
        public abstract Vector2 Direction { get; set; }
        public abstract bool Invincible { get; set; }
        public abstract bool Alive { get; set; }
        public abstract Vector2 Location { get; set; }
        public abstract Vector2 HurtBoxLocation { get; set; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        private Dictionary<Vector2, int> directionList = new Dictionary<Vector2, int>();
        private int directionTimer = 50;
        private int cooldown = 0;
        private List<Vector2> cardinalDirections = new List<Vector2>() { Vector2.UnitX, -Vector2.UnitX, Vector2.UnitY, -Vector2.UnitY};

        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Knockback(Vector2 direction);
        public virtual void Update()
        {
            List<Vector2> removed = new List<Vector2>();

            directionList = directionList.ToDictionary(something => something.Key, something => something.Value - 1);
            foreach (Vector2 r in removed)
            {
                directionList.Remove(r);
            }
            if( !directionList.ContainsKey(Direction))
            {
                directionList.Add(Direction, directionTimer);
            }
            cooldown--;
        }
        public virtual void DropItem()
        {
            Random random = new Random();
            if ( random.NextDouble() < 0.5d )
            {
                Console.WriteLine(game.KillCounter);
                ConstructorInfo info = LoZHelpers.DropTable[game.KillCounter].GetConstructor(new Type[] { typeof(Vector2), typeof(int)});
                IItem item = (IItem) info.Invoke(new object[] {Location, 100});
                game.Items.Add(item);
            }
        }
        public virtual void ChangeDirection(Direction direction = LegendOfZeldaClone.Direction.None)
        {
            if( LoZHelpers.DirectionToVector(direction) != Direction && cooldown > 0) { return; }
            cardinalDirections = new List<Vector2>() { Vector2.UnitX, -Vector2.UnitX, Vector2.UnitY, -Vector2.UnitY};
            cardinalDirections.RemoveAll((Vector2 v) => directionList.ContainsKey(v));
            if( cardinalDirections.Count == 0)
            {
                cardinalDirections = new List<Vector2>() { Vector2.UnitX, -Vector2.UnitX, Vector2.UnitY, -Vector2.UnitY};
                directionList.Clear();
            }
            Direction = cardinalDirections[LoZHelpers.random.Next() % cardinalDirections.Count];
            cooldown = 50;
        }
    }
}
