using LegendOfZeldaClone.Enemy;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class PhaseThreeIdle : IDodongoState
    {
        private Dodongo dodongo;
        private GameStateMachine g;
        private int timer = 20;
        public PhaseThreeIdle(Dodongo dodongo, GameStateMachine g)
        {
            this.dodongo = dodongo;
            this.g = g;
        }
        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                int r = LoZHelpers.random.Next() % 3;
                if (r == 0) dodongo.State = new CircleAttack(dodongo, g);
                else if( r == 1) dodongo.State = new CheckerboardAttack(dodongo, g);
                else dodongo.State = new HomingCircleAttack(dodongo, g);
            }
        }
    }
}
