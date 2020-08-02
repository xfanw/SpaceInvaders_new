using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TwoPlayerListener : InputListener
    {
        public override void Notify()
        {
            Debug.WriteLine("Two Player");
        }
    }
}