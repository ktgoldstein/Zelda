using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class SpiralAttack : IDodongoState
    {
        private readonly GameStateMachine game;
        private readonly Dodongo dodongo;
        private Vector2 Location;
        private int timer = 120;
        private int angle = 360;
        public SpiralAttack(Dodongo dodongo, GameStateMachine game)
        {
            this.dodongo = dodongo;
            this.game = game;
            Location = dodongo.Location;
        }
        public void Update()
        {
            angle -= 3;
            if (timer % 3 == 0)
                ShootFireball();
            if (timer == 0)
                dodongo.State = new PhaseOneIdle(dodongo, game);
            timer--;
        }
        private void ShootFireball()
        {
            Vector2 direction = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, direction));
        }
    }
}
