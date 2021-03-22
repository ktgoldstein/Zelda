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
            //DO NOT change the order of these without editing the other method returns!
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZArrowAndBoomerangLoopSound.wav")); //0
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBlueCandleUsingSound.wav")); //1
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBombExplodingSound.wav")); //2
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBombPlacingSound.wav")); //3
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBossScreamAquamentusSound.wav")); //4
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZBossTakeDamageSound.wav")); //5
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZDoorUnlockSound.wav")); //6
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZEnemyDyingSound.wav")); //7
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZEnemyTakeDamageSound.wav")); //8
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZGetInventoryItemOrFairyOrClockSound.wav")); //9
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZHeartOrKeyPickupSound.wav")); //10
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZKeyAppearSound.wav")); //11
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZLinkDyingSound.wav")); //12
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZLinkLowHealthLoopSound.wav")); //13
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZLinkTakeDamageSound.wav")); //14
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZMagicalRodUsingSound.wav")); //15
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZNewItemAcquiredFanfareSound.wav")); //16
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZRecorderPlayingSound.wav")); //17
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZRefillRupeesOrHeartsLoopSound.wav")); //18
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZRupeePickupSound.wav")); //19
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSecretDiscoveredSound.wav")); //20
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZShieldDeflectingSound.wav")); //21
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSwordBeamShootingSound.wav")); //22
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSwordCombinedSlashWithBeamShootingSound.wav")); //23
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZSwordSlashSound.wav")); //24
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZTextAndHeartRefillAndRupeeCountChangeLoopSound.wav")); //25
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZTextSlowLoopSound.wav")); //26
            allSoundEffects.Add(content.Load<SoundEffect>("Content/GameSounds/LOZWalkingOnStairsSound.wav")); //27

            allGameMusic.Add(content.Load<Song>("Content/GameSounds/LOZDungeonThemeLoopMusic.wav")); //0
            allGameMusic.Add(content.Load<Song>("Content/GameSounds/LOZGameOverThemeLoopMusic.wav")); //1
            allGameMusic.Add(content.Load<Song>("Content/GameSounds/LOZTriforceAcquiredFanfareMusic.wav")); //2
        }

        //Below: get methods--STILL UNFINISHED--also needs to be organized
        //Organizational note: Item Pickups & Inventory & Related Effects
        public SoundEffect GetHeartPickupSoundEffect() => allSoundEffects[10];
        public SoundEffect GetRupeePickupSoundEffect() => allSoundEffects[19];
        public SoundEffect GetClockPickupSoundEffect() => allSoundEffects[9];
        public SoundEffect GetKeyPickupSoundEffect() => allSoundEffects[10];
        public SoundEffect GetFairyPickupSoundEffect() => allSoundEffects[9];
        public SoundEffect GetInventoryItemPickupSoundEffect() => allSoundEffects[9];
        public SoundEffect GetNewImportantItemFanfareSoundEffect() => allSoundEffects[16];
        public SoundEffect GetRupeeCountChangingSoundEffect() => allSoundEffects[18];
        public SoundEffect GetHeartsRefillingSoundEffect() => allSoundEffects[18];
        public SoundEffect GetLowHealthBeepingSoundEffect() => allSoundEffects[13];
        public SoundEffect GetKeyAppearingSoundEffect() => allSoundEffects[11];

        //Organizational note: Using Items
        public SoundEffect GetArrowShootingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetBombPlacingSoundEffect() => allSoundEffects[3];
        public SoundEffect GetBombExplodingSoundEffect() => allSoundEffects[2];
        public SoundEffect GetBoomerangFlyingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetBlueCandleSoundEffect() => allSoundEffects[1];
        public SoundEffect GetShieldDeflectingSoundEffect() => allSoundEffects[21];
        public SoundEffect GetSwordBeamSoundEffect() => allSoundEffects[22];
        public SoundEffect GetSwordCombinedBeamAndSlashSoundEffect() => allSoundEffects[23];
        public SoundEffect GetSwordSlashSoundEffect() => allSoundEffects[24];

        //Organizational note: Link/enemy/boss sound effects
        public SoundEffect GetLinkTakingDamageSoundEffect() => allSoundEffects[0];
        public SoundEffect GetEnemyTakingDamageSoundEffect() => allSoundEffects[0];
        public SoundEffect GetBossTakingDamageSoundEffect() => allSoundEffects[0]; //used for all bosses in the game
        public SoundEffect GetAquamentusScreamingSoundEffect() => allSoundEffects[0]; //unique to Aquamentus and a few other bosses
        public SoundEffect GetLinkDyingSoundEffect() => allSoundEffects[0];
        public SoundEffect GetEnemyDyingSoundEffect() => allSoundEffects[0];

        //Organizational note: Environment & Other Misc sound effects
        public SoundEffect GetSecretRevealedSoundEffect() => allSoundEffects[20];
        public SoundEffect GetWalkingOnStairsSoundEffect() => allSoundEffects[27];
        public SoundEffect GetDoorUnlockingSoundEffect() => allSoundEffects[6];
        public SoundEffect GetTextAppearingSoundEffect() => allSoundEffects[25]; //will this not be used?
        public SoundEffect GetTextAppearingSlowlySoundEffect() => allSoundEffects[26];

        //Organizational note: Music
        public Song GetDungeonThemeMusic() => allGameMusic[0];
        public Song GetGameOverThemeMusic() => allGameMusic[1];
        public Song GetTriforceAcquiredFanfareMusic() => allGameMusic[2];
    }
}
