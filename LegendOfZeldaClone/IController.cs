using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;


namespace LegendOfZeldaClone
{
    public interface IController
    {
        void Update();
    }

    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private int chargeTimer = 0;
        private GameStateMachine game;
        public KeyboardController(GameStateMachine game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            bool hasZ = false;
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressedKeys)
            {
                if (key == Keys.Z)
                {
                    chargeTimer++;
                    hasZ = true;
                }
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
            if (!hasZ)
            {
                chargeTimer = 0;
            }
            if (chargeTimer > 15)
            {
                ICommand charge = new Charge(game);
                charge.Execute();
            }
        }
    }
    public class MouseController : IController
    {
        private ICommand leftClick;
        private ICommand rightClick;

        public MouseController(ICommand leftClickInput, ICommand rightClickInput)
        {
            leftClick = leftClickInput;
            rightClick = rightClickInput;
        }

        public void RegisterCommand() { }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.RightButton == ButtonState.Pressed)
                leftClick.Execute();
            else if (mouseState.LeftButton == ButtonState.Pressed)
                rightClick.Execute();
        }
    }
}
