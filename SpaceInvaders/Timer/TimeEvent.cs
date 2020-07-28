using System.Diagnostics;
using System.Security.Policy;

namespace SpaceInvaders
{
    public abstract class EventList : DLink
    {
        public EventList() : base()
        {

        }
    }
    public class TimeEvent : EventList
    {
        public enum NAME
        {
            SpriteAnimation,
            Uninitialized
        }

        public TimeEvent() : base()
        {
            this.name = NAME.Uninitialized;
            this.pCommand = null;

            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public void Set(TimeEvent.NAME name, Command pCommand, float deltaTimeToTrigger)
        {
            this.name = name;

            Debug.Assert(pCommand != null);
            this.pCommand = pCommand;
            this.deltaTime = deltaTimeToTrigger;

            this.triggerTime = TimerMan.GetCurrTime() + deltaTimeToTrigger;
        }

        public void Process()
        {
            Debug.Assert(this.pCommand != null);

            this.pCommand.Execute(deltaTime);
        }

        public void Wash()
        {
            // Wash - clear the entire hierarchy
            base.Clear();

            this.name = TimeEvent.NAME.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public TimeEvent.NAME GetName()
        {
            return this.name;
        }
        public void Dump()
        {

            // Dump - Print contents to the debug output window
            //        Using HASH code as its unique identifier 
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("      Command: {0}", this.pCommand);
            Debug.WriteLine("   Event Name: {0}", this.name);
            Debug.WriteLine(" Trigger Time: {0}", this.triggerTime);
            Debug.WriteLine("   Delta Time: {0}", this.deltaTime);

            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Image pTmp = (Image)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                Image pTmp = (Image)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }
        }
        // Data : ----------
        private NAME name;
        public Command pCommand;

        public float triggerTime;
        public float deltaTime;

    }
}
