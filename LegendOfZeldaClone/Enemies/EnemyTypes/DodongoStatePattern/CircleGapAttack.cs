using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class CircleGapAttack : IDodongoState
    {
        private GameStateMachine game;
        private Dodongo dodongo;
        private float angle = 0;
        private float rotationSpeed = 1;
        private Vector2 Location;
        private int timer = 150;
        public CircleGapAttack(Dodongo dodongo, GameStateMachine g)
        {
            this.dodongo = dodongo;
            game = g;
        }
        public void Update()
        {
            Location = dodongo.Location;
            dodongo.Move();
            timer--;
            angle += rotationSpeed;
            if (timer % 50 == 0) FireBallCircleOne();
            if( timer % 80 == 0) FireBallCircleTwo();
            if (timer == 0)
            {
                dodongo.State = new PhaseTwoIdle(dodongo, game);
            }
        }
        public void FireBallCircleOne()
        {
            for (int angle = 0; angle <= 360; angle += 45)
            {
                Vector2 one = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180));
                game.EnemyProjectilesQueue.Add(new Fireball(Location, one));
            }
        }
        public void FireBallCircleTwo()
        {
            for (int angle = 0; angle <= 360; angle += 30)
            {
                Vector2 one = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180));
                game.EnemyProjectilesQueue.Add(new Fireball(Location, one));
            }
        }
    }
}
