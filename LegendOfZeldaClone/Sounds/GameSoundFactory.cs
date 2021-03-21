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

        public List<SoundEffect> allSoundEffects;
        private List<Song> allGameMusic;

        public void LoadAllSounds(ContentManager content)
        {
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZArrowAndBoomerangLoopSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBlueCandleUsingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBombExplodingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBombPlacingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBossScreamAquamentusSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBossTakeDamageSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZDoorUnlockSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZEnemyDyingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZEnemyTakeDamageSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZGetInventoryItemOrFairyOrClockSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZHeartPickupSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZKeyAppearSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZLinkDyingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZLinkLowHealthLoopSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZLinkTakeDamageSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZMagicalRodUsingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZNewItemAcquiredFanfareSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZRecorderPlayingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZRefillRupeesOrHeartsLoopSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZRupeePickupSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSecretDiscoveredSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZShieldDeflectingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSwordBeamShootingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSwordCombinedSlashWithBeamShootingSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSwordSlashSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZTextAndHeartRefillAndRupeeCountChangeLoopSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZTextSlowLoopSound.wav"));
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZWalkingOnStairsSound.wav"));

            allGameMusic.Add(content.Load<Song>("Content/GameSounds/LOZDungeonThemeLoopMusic.wav"));
            allGameMusic.Add(content.Load<Song>("Content/GameSounds/LOZGameOverThemeLoopMusic.wav"));
            allGameMusic.Add(content.Load<Song>("Content/GameSounds/LOZTriforceAcquiredFanfareMusic.wav"));
            //note: i think the TriforceAquiredFanfare should maybe be made into a sound effect instead, but idk yet
        }

        //Below: get methods--STILL UNFINISHED--also needs to be organized
        public SoundEffect GetHeartPickupSoundEffect() => allSoundEffects[0];
        public SoundEffect GetRupeePickupSoundEffect() => allSoundEffects[0];
        public SoundEffect GetClockPickupSoundEffect() => allSoundEffects[0];
        public SoundEffect GetImportantItemPickupSoundEffect() => allSoundEffects[0];
        public SoundEffect GetArrowShootingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetSwordSlashSoundEffect() => allSoundEffects[0];
        public SoundEffect GetSwordBeamSoundEffect() => allSoundEffects[0];
        public SoundEffect GetBombPlacingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetBombExplodingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetArrowSoundEffect() => allSoundEffects[0];
        public SoundEffect GetLinkTakingDamageSoundEffect() => allSoundEffects[0];
        public SoundEffect GetEnemyTakingDamageSoundEffect() => allSoundEffects[0];
        public SoundEffect GetBossTakingDamageSoundEffect() => allSoundEffects[0]; 
        //^note to self: should this be GetAquamentusTakingDamageSoundEffect()?
        public SoundEffect GetLowHealthBeepingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetRupeeAddedToInventorySoundEffect() => allSoundEffects[0];
        public SoundEffect GetSecretRevealedSoundEffect() => allSoundEffects[0];
        public SoundEffect GetItemAppearingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetWalkingOnStairsSoundEffect() => allSoundEffects[0];
        public SoundEffect GetAquamentusScreamingSoundEffect() => allSoundEffects[0];
        //^similar note as before: should this be GetBossScreamingSoundEffect()?
        public SoundEffect GetLinkDyingSoundEffect() => allSoundEffects[0];

    }
}
