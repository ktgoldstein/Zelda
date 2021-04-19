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
        private readonly Direction[] attackDirections = { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
        private Direction currentAttackDirection;
        private int currentAttackIndex;
        private int angle = 360;
        public SpiralAttack(Dodongo dodongo, GameStateMachine game)
        {
            this.dodongo = dodongo;
            this.game = game;
            currentAttackIndex = 0;
            currentAttackDirection = attackDirections[currentAttackIndex];
            Location = dodongo.Location;
        }
        public void Update()
        {
            angle -= 3;
            if (timer % 3 == 0)
                ShootFireball();
            UpdateCurrentAttackDirection();
            if (timer == 0)
                dodongo.State = new PhaseOneIdle(dodongo, game);
            timer--;
        }
        private void ShootFireball()
        {
               // Vector2 direction = LoZHelpers.DirectionToVector(currentAttackDirection);
            Vector2 direction = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, direction));
        }
        private void UpdateCurrentAttackDirection()
        {
            if (timer % 20 == 0)
            {
                if (currentAttackIndex < 3)
                    currentAttackIndex++;
                else
                    currentAttackIndex = 0;
                currentAttackDirection = attackDirections[currentAttackIndex];
            }
        }
    }
}
