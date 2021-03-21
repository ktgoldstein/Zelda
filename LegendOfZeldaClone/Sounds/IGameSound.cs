using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LegendOfZeldaClone
{
    //put in LoZHelpers if this ends up being necessary to keep
    public enum SoundTypes
    {
        MusicSoundtrack,
        SoundEffectSoundtrack
    }

    public interface IGameSound
    {
        public SoundEffect GameSoundEffect { get; }
        public Song GameMusic { get; }
        public SoundTypes SoundType { get; }
        /*note about above: idea rn is that you'll check for what type and 
         * if it's MusicSoundtrack then you get the GameMusic and if it's 
         * a SoundEffectSoundtrackthen you get the GameSoundEffect property. 
         Subject to change as time goes on. (Alternative idea: two different interfaces entirely)*/
        public bool IsLoopable { get; }
    }
}
