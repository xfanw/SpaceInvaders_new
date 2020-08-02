using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileHitAlienSnd : ColListener
    {

        public override void Notify()
        {
           // Debug.WriteLine(" Snd_Listener: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);
            Debug.WriteLine("Missile Hit Alien Sound");

            SoundMan.Play(Sound.Name.Snd_Explosion);
        }
    }
}
