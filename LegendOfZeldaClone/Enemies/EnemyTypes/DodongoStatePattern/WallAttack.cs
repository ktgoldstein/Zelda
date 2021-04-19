using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class WallAttack : IDodongoState
    {
        private GameStateMachine game;
        private Dodongo dodongo;
        private Vector2 Location;
        private int timer = 100;
        public WallAttack(Dodongo dodongo, GameStateMachine g)
        {
            this.dodongo = dodongo;
            game = g;
        }
        public void Update()
        {
            Location = dodongo.Location;
            dodongo.Move();
            timer--;
            if (timer % 50 == 0) FireballWall();
            if (timer == 0)
            {
                dodongo.State = new PhaseTwoIdle(dodongo, game);
            }
        }
        public void FireballWall()
        {
            int fireballNumber = 24;
            Vector2 linkDirection = game.Player.Location - Location;
            linkDirection.Normalize();
            for( int i = -fireballNumber/2; i < fireballNumber/2; i++)
            {
                Vector2 target = new Vector2(-linkDirection.Y,linkDirection.X);
                target *= i*6*48;
                target /= fireballNumber/2;
                target += Location;
                game.EnemyProjectilesQueue.Add(new Fireball(Location, Vector2.Zero, -1, false, null, true, target, linkDirection));
            }
        }
    }
}
