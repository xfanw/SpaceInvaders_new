using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipShootListener : InputListener
    {
        public override void Notify()
        {
            Debug.WriteLine("Shoot Listener");
        }
    }
}