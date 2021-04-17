using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone
{
    public class OrbSwitch : BlockKernel
    {
        public bool WasHit { get; set; } = false;

        public OrbSwitch(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight)
            :base (location, sprite, height, width, objectHeight, false, false)
        { }
        public void Reset() => WasHit = false;
    }
}
