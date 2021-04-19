using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class LinearAttack : IDodongoState
    {
        private readonly GameStateMachine game;
        private readonly Dodongo dodongo;
        private Vector2 Location;
        private int timer = 60;
        private readonly Direction[] attackDirections = { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
        private Direction currentAttackDirection;
        private int currentAttackIndex;
        public LinearAttack(Dodongo dodongo, GameStateMachine game)
        {
            this.dodongo = dodongo;
            this.game = game;
            currentAttackIndex = 0;
            currentAttackDirection = attackDirections[currentAttackIndex];
            Location = dodongo.Location;
        }
        public void Update()
        {
            if (timer % 3 == 0)
                ShootFireball();
            UpdateCurrentAttackDirection();
            if (timer == 0)
                dodongo.State = new PhaseOneIdle(dodongo, game);
            timer--;
        }
        private void ShootFireball()
        {
                Vector2 direction = LoZHelpers.DirectionToVector(currentAttackDirection);
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
