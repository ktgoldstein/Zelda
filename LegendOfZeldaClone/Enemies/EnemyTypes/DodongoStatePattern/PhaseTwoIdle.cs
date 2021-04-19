using LegendOfZeldaClone.Enemy;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class PhaseTwoIdle : IDodongoState
    {
        private Dodongo dodongo;
        private GameStateMachine g;
        private int timer = 20;
        public PhaseTwoIdle(Dodongo dodongo, GameStateMachine g)
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
                if (r == 0) dodongo.State = new CircleGapAttack(dodongo, g);
                else if( r == 1) dodongo.State = new HelicopterAttack(dodongo, g);
                else dodongo.State = new WallAttack(dodongo, g);
            }
        }
    }
}
