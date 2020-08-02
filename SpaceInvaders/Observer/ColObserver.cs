using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ColListener : DLink
    {
        public abstract void Notify();

        public ColObserver pSubject;
    }
}
