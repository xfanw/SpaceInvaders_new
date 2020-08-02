using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class OnePlayerListener : InputListener
    {
        public override void Notify()
        {
            Debug.WriteLine("One Player");
        }
    }
}