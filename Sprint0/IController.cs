using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
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
        private Dictionary<string, ICommand> controllerMappings;
        private LegendOfZeldaClone myGame;

        public MouseController(LegendOfZeldaClone game)
        {
            controllerMappings = new Dictionary<string, ICommand>();
            myGame = game;
        }

        public void RegisterCommand(string key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();

            if(mouseState.RightButton == ButtonState.Pressed)
            {
                controllerMappings["rightClick"].Execute();
            }
            else if (mouseState.LeftButton == ButtonState.Pressed)
            {
                bool clickedOnTop = mouseState.Y < myGame.GameHeight /2;
                bool clickedOnLeft = mouseState.X < myGame.GameWidth /2;
                string clickLocation = clickedOnTop ? "top" : "bottom";
                clickLocation += clickedOnLeft ? "Left" : "Right";

                controllerMappings[$"leftClick {clickLocation}"].Execute();
            }
        }
    }
}
