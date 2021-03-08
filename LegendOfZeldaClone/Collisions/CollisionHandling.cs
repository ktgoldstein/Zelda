namespace LegendOfZeldaClone.Collisions
{
    public static class CollisionHandling 
    {
        public static void HandleCollisions(LegendOfZeldaDungeon game)
        {
            PlayerCollisionHandler.Instance.CurrentPlayer = game.Link;
            

        }
    }
}
