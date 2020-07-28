
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerMan : Manager
    {
        private TimerMan(int init = 2, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            Debug.Assert(pMan == null);

            if (pMan == null)
            {
                pMan = new TimerMan(init, delta);
            }

        }

        public static void Destroy()
        {

            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            pMan.baseDestroy();
            // invalidate the singleton

            pMan = null;
        }

        public static void Update(float totalTime)
        {
            Debug.Assert(pMan != null);

            // squirrel away
            pMan.mCurTime = totalTime;

            // walk the list
            TimeEvent pEvent = (TimeEvent)pMan.poActive;
            TimeEvent pNextEvent = null;

            // Walk the list until there is no more list OR currTime is greater than timeEvent 
            // ToDo Fix: List needs to be sorted
            while (pEvent != null /*&& (pMan.mCurTime >= pEvent.triggerTime)*/)
            {
                pNextEvent = (TimeEvent)pEvent.pNext;

                if (pMan.mCurTime >= pEvent.triggerTime)
                {
                    pEvent.Process();

                    pMan.baseRemove(pEvent);
                }

                // advance the pointer
                pEvent = pNextEvent;
            }
        }

        public static float GetCurrTime()
        {
            Debug.Assert(pMan != null);

            // return time
            return pMan.mCurTime;
        }

        public static TimeEvent Add(TimeEvent.NAME name, Command pCommand, float deltaTimeToTrigger)
        {
            Debug.Assert(pMan != null);

            TimeEvent pEvent = (TimeEvent)pMan.baseAdd();
            Debug.Assert(pEvent != null);
          
            Debug.Assert(pCommand != null);

            pEvent.Set(name, pCommand, deltaTimeToTrigger);
            return pEvent;
        }

        public static void Remove(TimeEvent pEvent)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pEvent != null);

            pMan.baseRemove(pEvent);

            pEvent.Wash();
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static TimeEvent Find(TimeEvent.NAME name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((TimeEvent)ptr).GetName() == name)
                {
                    return (TimeEvent)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }



        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TimeEvent pData = (TimeEvent)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new TimeEvent();
        }


        // Data: ----------
        private static TimerMan pMan;
        private float mCurTime;
    }
}