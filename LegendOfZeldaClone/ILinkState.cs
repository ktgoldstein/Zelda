using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkNormalStandingDown : ILinkState
    {
        public LinkNormalStandingDown()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }


    }

    public class LinkNormalStandingUp : ILinkState
    {
        public LinkNormalStandingUp()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalStandingLeft : ILinkState
    {

        public LinkNormalStandingLeft()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalStandingRight : ILinkState
    {
        public LinkNormalStandingRight()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalWalkingDown : ILinkState
    {
        public LinkNormalWalkingDown()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalWalkingUp : ILinkState
    {
        public LinkNormalWalkingUp()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalWalkingLeft : ILinkState
    {
        public LinkNormalWalkingLeft()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }
    public class LinkNormalWalkingRight : ILinkState
    {
        public LinkNormalWalkingRight()
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    // Simon edit after this comment

}
