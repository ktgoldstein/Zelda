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

        private MouseState oldMouseState;
        private MouseState newMouseState;


        private Dictionary<ButtonState, ICommand> mouseMappings;

        public MouseController()
        {
            oldMouseState = Mouse.GetState();
            mouseMappings = new Dictionary<ButtonState, ICommand>();
        }

        public void RegisterCommand(ButtonState button, ICommand command)
        {
            mouseMappings.Add(ButtonState.Pressed, command);
        }
        public void Update()
        {
            newMouseState = Mouse.GetState();
            List<ButtonState> buttons = new List<ButtonState>();
            buttons.Add(newMouseState.LeftButton);

            if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                foreach (ButtonState buttonState in buttons)
                {
                    if (mouseMappings.ContainsKey(buttonState))
                    {
                        mouseMappings[buttonState].Execute();
                    }
                }
            }

            oldMouseState = newMouseState;

        }

    }
}
