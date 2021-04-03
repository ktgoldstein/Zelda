using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Display
{
    public class Camera
    {
        private GameStateMachine game;
        private Vector2 position = Vector2.Zero;
        private Vector2 targetPosition;
        private readonly int speed = LoZHelpers.Scale(8);
        private Direction currentTransitionDirection;

        public Camera(GameStateMachine game)
        {
            this.game = game;
        }

        public void Reset()
        {
            position = Vector2.Zero;
            targetPosition = position;
            currentTransitionDirection = Direction.None;
        }

        public void CameraTransition(Direction direction)
        {
            if (game.CurrentGameState == GameState.Play)
            {
                currentTransitionDirection = direction;
                game.CurrentGameState = GameState.ScreenTransition;
                switch (direction)
                {
                    case Direction.Up:
                        targetPosition = position + new Vector2
                            (0, LoZHelpers.GameHeight - LoZHelpers.HUDHeight);
                        break;
                    case Direction.Down:
                        targetPosition = position - new Vector2
                            (0, LoZHelpers.GameHeight - LoZHelpers.HUDHeight);
                        break;
                    case Direction.Left:
                        targetPosition = position + new Vector2(LoZHelpers.GameWidth, 0);
                        break;              
                    case Direction.Right:
                        targetPosition = position + new Vector2(-LoZHelpers.GameWidth, 0);
                        break;
                    default:
                        break;
                }
            }           
        }

        public void Update()
        {
            if (targetPosition != position)
            {
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                position += direction * speed;
            }
            else if (game.CurrentGameState == GameState.ScreenTransition)
            {
                game.CurrentGameState = GameState.Play;
                game.CurrentRoom = game.NextRoom;
                game.NextRoom = null;
                game.ShiftLink(currentTransitionDirection);
            }
        }

        public Matrix Translation()
        {
            return Matrix.CreateTranslation(position.X, position.Y, 0);
        }     
    }    
}
