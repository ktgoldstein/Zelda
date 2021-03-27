﻿namespace LegendOfZeldaClone
{
    public interface IItem : IGameObject
    {
        public bool Alive { get; set; }
        public void BeCollected();
    }
}
