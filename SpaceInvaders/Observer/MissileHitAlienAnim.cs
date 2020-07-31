using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileHitAlienAnim : ColObserver
    {
        public MissileHitAlienAnim()
        {

        }
        public override void Notify()
        {
            Debug.WriteLine("Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);
            Debug.WriteLine("Missile Hit Alien ---> Play Animation.");

        }
    }
}
