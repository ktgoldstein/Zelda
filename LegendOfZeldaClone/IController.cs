using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace LegendOfZeldaClone
{
    public interface IController 
    {
        void Update();
    }

    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
    public class MouseController : IController
    {
        private LegendOfZeldaDungeon myGame;
        private ICommand leftClick;
        private ICommand rightClick;

        public MouseController(LegendOfZeldaDungeon game, ICommand leftClickInput, ICommand rightClickInput)
        {
            leftClick = leftClickInput;
            rightClick = rightClickInput;
            myGame = game;
        }

        public void RegisterCommand(string key, ICommand command)
        {
            // Don't use RegisterCommand for this Controller
        }

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
