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
    public class GameSoundFactory
    {
        public static GameSoundFactory Instance { get; } = new GameSoundFactory();

        private List<SoundEffect> allSoundEffects;
        private List<Song> allGameMusic;

        public void LoadAllSounds(ContentManager content)
        {
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZArrowAndBoomerangLoopSound.wav"));

        }

    }
}
