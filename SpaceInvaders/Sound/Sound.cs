using System;

namespace SpaceInvaders
{
    public class Sound : DLink
    {
        public enum Name
        {
            Snd_Explosion,
            Snd_Invader1,
            Snd_Invader2,
            Snd_Invader3,
            Snd_Invader4,
            Snd_InvaderKilled,
            Snd_Shoot,
            Snd_Theme,
            Snd_UFO1,
            Snd_UFO2,
            Snd_HitWall,

            Snd_Uninitialized
        }
        public Sound()
        {
            this.name = Name.Snd_Uninitialized;
            this.src = null;
        }

        public void Set(Sound.Name name, IrrKlang.ISoundSource snd)
        {
            this.name = name;
            this.src = snd;
        }

        public void Wash()
        {
            this.name = Name.Snd_Uninitialized;
            src = null;
        }
        public void SetVolume(float vol)
        {
            this.volume = vol;
        }
        public float GetVolume()
        {
            return this.volume;
        }
        public Sound.Name GetName()
        {
            return this.name;
        }

        public IrrKlang.ISoundSource GetSource()
        {
            return this.src;
        }
        // Data : ----------
        private Sound.Name name;
        public IrrKlang.ISoundSource src;
        private float volume = 0.0f;
    }
}
