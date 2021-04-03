using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Display
{
    public class Camera
    {
        private GameStateMachine game;
        private Vector2 position = Vector2.Zero;
        private Vector2 targetPosition;
        private readonly int speed = LoZHelpers.Scale(8);
        private Direction currentTransitionDirection = Direction.None;
        private bool active = false;

        public Camera(GameStateMachine game)
        {
            this.game = game;
            targetPosition = position;
        }

        public void Reset()
        {
            position = Vector2.Zero;
            targetPosition = position;
            currentTransitionDirection = Direction.None;
        }

        public void CameraTransition(Direction direction, GameState newGameState)
        {
            if (game.CurrentGameState == GameState.ScreenTransition) return;
            if (game.CurrentGameState == GameState.PauseTransition) return;

            active = true;
            game.CurrentGameState = newGameState;
            currentTransitionDirection = direction;
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

        public void Update()
        {
            if (!active) return;
            if ((targetPosition - position).Length() != 0)
            {
                Vector2 direction = targetPosition - position;
                if (direction.Length() < 8)
                    position = targetPosition;
                else
                {
                    direction.Normalize();
                    position += direction * speed;
                }
                return;
            }
            else if (game.CurrentGameState == GameState.ScreenTransition)
            {
                game.CurrentGameState = GameState.Play;
                game.CurrentRoom = game.NextRoom;
                game.NextRoom = null;
                game.ShiftLink(currentTransitionDirection);
                active = false;
            }
            else if (game.CurrentGameState == GameState.PauseTransition)
            {
                if (game.PreviousGameState == GameState.Play)
                    game.CurrentGameState = GameState.Pause;
                else
                    game.CurrentGameState = GameState.Play;
                active = false;
            }
        }

        public Matrix Translation()
        {
            return Matrix.CreateTranslation(position.X, position.Y, 0);
        }     
    }    
}
