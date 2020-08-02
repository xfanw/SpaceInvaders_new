using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveRightListener : InputListener
    {
        public override void Notify()
        {
            Debug.WriteLine("Move Right Listener");
        }
    }
}