using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern
{
    class CheckerboardAttack : IDodongoState
    {
        private Dodongo dodongo;
        private int timer = 120;
        private GameStateMachine game;
        private int something;
        public CheckerboardAttack(Dodongo dodongo, GameStateMachine g)
        {
            this.dodongo = dodongo;
            game = g;
            EntireRoomFireball();
        }
        public void Update()
        {
            dodongo.Move();
            timer--;
            if(timer % 30 == 0)
            {
                EntireRoomFireball();
            }
            if(timer == 0)
            {
                dodongo.State = new PhaseThreeIdle(dodongo, game);
            }
        }
        public void EntireRoomFireball()
        {
            Vector2 topLeftCorner = game.CurrentRoom.PixelOffset + new Vector2(LoZHelpers.GameWidth / 2, (LoZHelpers.GameHeight - LoZHelpers.HUDHeight) / 2) - new Vector2(6 * 48, 3.5f * 48) + new Vector2(12, 12);
            for (int i = 0; i < LoZHelpers.FireballArray.GetLength(0); i++)
            {
                for (int j = 0; j < LoZHelpers.FireballArray.GetLength(1); j++)
                {
                    if (LoZHelpers.FireballArray[i, j] == something)
                    {
                        game.EnemyProjectilesQueue.Add(new Fireball(topLeftCorner + Vector2.UnitX * j * 48 + Vector2.UnitY * i * 48, Vector2.Zero, 20));
                    }
                }
            }
            something = 1 - something;
        }
    }
}
