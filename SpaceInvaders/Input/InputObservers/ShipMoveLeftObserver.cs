using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveLeftListener : InputListener
    {
        public override void Notify()
        {
            Debug.WriteLine("Move Left Listener");
        }
    }
}