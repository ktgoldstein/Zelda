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
        private List<SoundEffect> allGameMusic;

        private GameSoundFactory()
        {
            allSoundEffects = new List<SoundEffect>();
            allGameMusic = new List<SoundEffect>();
        }

        public void LoadAllSounds(ContentManager content)
        {
            //DO NOT change the order of these without editing the other method returns!
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZArrowAndBoomerangLoopSound")); //0
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZBlueCandleUsingSound")); //1
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZBombExplodingSound")); //2
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZBombPlacingSound")); //3
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZBossScreamAquamentusSound")); //4
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZBossTakeDamageSound")); //5
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZDoorUnlockSound")); //6
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZEnemyDyingSound")); //7
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZEnemyTakeDamageSound")); //8
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZGetInventoryItemOrFairyOrClockSound")); //9
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZHeartOrKeyPickupSound")); //10
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZKeyAppearSound")); //11
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZLinkDyingSound")); //12
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZLinkLowHealthLoopSound")); //13
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZLinkTakeDamageSound")); //14
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZMagicalRodUsingSound")); //15
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZNewItemAcquiredFanfareSound")); //16
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZRecorderPlayingSound")); //17
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZRefillRupeesOrHeartsLoopSound")); //18
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZRupeePickupSound")); //19
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZSecretDiscoveredSound")); //20
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZShieldDeflectingSound")); //21
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZSwordBeamShootingSound")); //22
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZSwordCombinedSlashWithBeamShootingSound")); //23
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZSwordSlashSound")); //24
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZTextAndHeartRefillAndRupeeCountChangeLoopSound")); //25
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZTextSlowLoopSound")); //26
            allSoundEffects.Add(content.Load<SoundEffect>("GameSounds/LOZWalkingOnStairsSound")); //27

            //Music--previously these were of type Song and not SoundEffect, so this may be refactored out
            allGameMusic.Add(content.Load<SoundEffect>("GameSounds/LOZDungeonThemeLoopMusic")); //0
            allGameMusic.Add(content.Load<SoundEffect>("GameSounds/LOZGameOverThemeLoopMusic")); //1
            allGameMusic.Add(content.Load<SoundEffect>("GameSounds/LOZTriforceAcquiredFanfareMusic")); //2
            allGameMusic.Add(content.Load<SoundEffect>("GameSounds/CustomBossThemeMusic"));
        }

        //Organizational note: Item Pickups & Inventory & Related Effects
        public SoundEffect GetHeartPickupSoundEffect() => allSoundEffects[10];
        public SoundEffect GetRupeePickupSoundEffect() => allSoundEffects[19];
        public SoundEffect GetClockPickupSoundEffect() => allSoundEffects[9];
        public SoundEffect GetKeyPickupSoundEffect() => allSoundEffects[10];
        public SoundEffect GetFairyPickupSoundEffect() => allSoundEffects[9];
        public SoundEffect GetInventoryItemPickupSoundEffect() => allSoundEffects[9];
        public SoundEffect GetNewImportantItemAcquiredFanfareSoundEffect() => allSoundEffects[16];
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
        public SoundEffect GetLinkTakingDamageSoundEffect() => allSoundEffects[14];
        public SoundEffect GetEnemyTakingDamageSoundEffect() => allSoundEffects[8];
        public SoundEffect GetBossTakingDamageSoundEffect() => allSoundEffects[5]; //used for all bosses in the game
        public SoundEffect GetAquamentusScreamingSoundEffect() => allSoundEffects[4]; //unique to Aquamentus and only a few other bosses
        public SoundEffect GetLinkDyingSoundEffect() => allSoundEffects[12];
        public SoundEffect GetEnemyDyingSoundEffect() => allSoundEffects[7];

        //Organizational note: Environment & Other Misc sound effects
        public SoundEffect GetSecretRevealedSoundEffect() => allSoundEffects[20];
        public SoundEffect GetWalkingOnStairsSoundEffect() => allSoundEffects[27];
        public SoundEffect GetDoorUnlockingSoundEffect() => allSoundEffects[6];
        public SoundEffect GetTextAppearingSoundEffect() => allSoundEffects[25];
        public SoundEffect GetTextAppearingSlowlySoundEffect() => allSoundEffects[26];

        //Organizational note: Music
        public SoundEffect GetDungeonThemeMusic() => allGameMusic[0];
        public SoundEffect GetGameOverThemeMusic() => allGameMusic[1];
        public SoundEffect GetTriforceAcquiredFanfareMusic() => allGameMusic[2];
        public SoundEffect GetCustomBossThemeMusic() => allGameMusic[3];
    }
}
