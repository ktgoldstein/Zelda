using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class DoubleLinearAttack : IDodongoState
    {
        private readonly GameStateMachine game;
        private readonly Dodongo dodongo;
        private Vector2 Location;
        private int timer = 80;
        private readonly Direction[] attackDirections = { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
        private Direction firstCurrentAttackDirection;
        private Direction secondCurrentAttackDirection;
        private int firstCurrentAttackIndex;
        private int secondCurrentAttackIndex;
        public DoubleLinearAttack(Dodongo dodongo, GameStateMachine game)
        {
            this.dodongo = dodongo;
            this.game = game;
            firstCurrentAttackIndex = 0;
            secondCurrentAttackIndex = 1;
            firstCurrentAttackDirection = attackDirections[firstCurrentAttackIndex];
            secondCurrentAttackDirection = attackDirections[secondCurrentAttackIndex];
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
            Vector2 direction = LoZHelpers.DirectionToVector(firstCurrentAttackDirection);
            Vector2 secondDirection = LoZHelpers.DirectionToVector(secondCurrentAttackDirection);
            game.EnemyProjectilesQueue.Add(new Fireball(Location, direction));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, secondDirection));
        }
        private void UpdateCurrentAttackDirection()
        {
            if (timer % 20 == 0)
            {
                if (firstCurrentAttackIndex < 3)
                    firstCurrentAttackIndex++;
                else
                    firstCurrentAttackIndex = 0;

                if (secondCurrentAttackIndex < 3)
                    secondCurrentAttackIndex++;
                else
                    secondCurrentAttackIndex = 0;
                firstCurrentAttackDirection = attackDirections[firstCurrentAttackIndex];
                secondCurrentAttackDirection = attackDirections[secondCurrentAttackIndex];
            }
        }
    }
}
