using LegendOfZeldaClone.Enemy;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class PhaseOneIdle : IDodongoState
    {
        private Dodongo dodongo;
        private GameStateMachine g;
        private int timer = 40;
        public PhaseOneIdle(Dodongo dodongo, GameStateMachine g)
        {
            this.dodongo = dodongo;
            this.g = g;

        }
        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                int randomSeed = LoZHelpers.random.Next() % 3;
                if (randomSeed == 0)
                    dodongo.State = new LinearAttack(dodongo, g);
                else if (randomSeed == 1)
                    dodongo.State = new DoubleLinearAttack(dodongo, g);
                else
                    dodongo.State = new SpiralAttack(dodongo, g);
                //dodongo.State = new SpiralAttack(dodongo, g);
            }
        }
    }
}
