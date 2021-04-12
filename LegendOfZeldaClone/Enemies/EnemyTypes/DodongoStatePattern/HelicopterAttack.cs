using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class HelicopterAttack : IDodongoState
    {
        private GameStateMachine game;
        private Dodongo dodongo;
        private float angle = 0;
        private float rotationSpeed = 1;
        private Vector2 Location;
        private int timer = 150;
        public HelicopterAttack(Dodongo dodongo, GameStateMachine g)
        {
            this.dodongo = dodongo;
            game = g;
            Location = dodongo.Location;
        }
        public void Update()
        {
            timer--;
            angle += rotationSpeed;
            if (angle > 360)
            {
                angle -= 360;
            }
            FireBallStream();
            if(timer == 0)
            {
                dodongo.State = new PhaseOneIdle(dodongo, game);
            }
        }
        public void FireBallStream()
        {
            Vector2 one = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180));
            Vector2 two = new Vector2((float)Math.Cos(angle * Math.PI / 180 + Math.PI / 2), (float)Math.Sin(angle * Math.PI / 180 + Math.PI / 2));
            Vector2 three = new Vector2((float)Math.Cos(angle * Math.PI / 180 + Math.PI), (float)Math.Sin(angle * Math.PI / 180 + Math.PI));
            Vector2 four = new Vector2((float)Math.Cos(angle * Math.PI / 180 + Math.PI * 3 / 2), (float)Math.Sin(angle * Math.PI / 180 + Math.PI * 3 / 2));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, one));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, two));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, three));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, four));
        }
    }
}
