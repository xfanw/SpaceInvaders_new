using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ToggleBoxListener : InputListener
    {
        public override void Notify()
        {
            Debug.WriteLine("Box On/Off Listener");
        }
    }
}