using IrrKlang;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundMan : Manager
    {
        // private Constructor
        private SoundMan(int init = 5, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 5, int delta = 3)
        {
            if (pMan == null)
            {
                pMan = new SoundMan(init, delta);
                pMan.sndEngine = new ISoundEngine();
                pMan.playing = null;
            }
        }

        public static void Play(Sound.Name name)
        {
            Debug.Assert(pMan != null);
            Sound snd = Find(name);
            Debug.Assert(snd != null);
            Debug.Assert(snd.GetSource() != null);
            pMan.sndEngine.Play2D(snd.GetSource(), false, false, false);
        }

        public static void PlayMusic(Sound.Name name)
        {
            Debug.Assert(pMan != null);
            Sound snd = Find(name);
            Debug.Assert(snd != null);
            pMan.playing = pMan.sndEngine.Play2D(snd.GetSource(), false, false, false);
        }

        public static void Stop()
        {
            Debug.Assert(pMan != null);
            pMan.playing.Stop();
        }

        public static void Destroy()
        {
            Debug.Assert(pMan != null);
            pMan.baseDestroy();

            // invalidate the singleton
            pMan = null;
        }
        public static Sound Add(Sound.Name name, string path)
        {
            Debug.Assert(pMan != null);
            Sound pSound = (Sound)pMan.baseAdd();
            Debug.Assert(pSound != null);
            IrrKlang.ISoundSource soundSource = pMan.sndEngine.AddSoundSourceFromFile(path);
            pSound.Set(name, soundSource);
            return pSound;
        }

        public static Sound Find(Sound.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Sound)ptr).GetName() == name)
                {
                    return (Sound)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }

        public static void Remove(Sound pSound)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pSound != null);

            pMan.baseRemove(pSound);
            pSound.Wash();
        }
        protected override DLink derivedCreate()
        {
            return new Sound();
        }

        protected override void derivedDump(DLink pNode)
        {
            //;
        }

        public static void LoadAll()
        {
            Debug.WriteLine("...Loading Sound...");
            Add(Sound.Name.Snd_Explosion, "explosion.wav");
            Add(Sound.Name.Snd_Invader1, "fastinvader1.wav");
            Add(Sound.Name.Snd_Invader2, "fastinvader2.wav");
            Add(Sound.Name.Snd_Invader3, "fastinvader3.wav");
            Add(Sound.Name.Snd_Invader4, "fastinvader4.wav");
            Add(Sound.Name.Snd_InvaderKilled, "invaderkilled.wav");
            Add(Sound.Name.Snd_Shoot, "shoot.wav");
            Add(Sound.Name.Snd_Theme, "theme.wav");
            Add(Sound.Name.Snd_UFO1, "ufo_highpitch.wav");
            Add(Sound.Name.Snd_UFO2, "ufo_lowpitch.wav");
            Add(Sound.Name.Snd_HitWall, "UFODie.mp3");
            Debug.WriteLine("Done!");
        }
        // Data : ------------
        private static SoundMan pMan;
        private ISoundEngine sndEngine;
        private ISound playing;
    }
}
