using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class InputListener : ColListener { }
    public class InputObserver : ColObserver { }

    public class InputMan
    {
        private InputMan()
        {
            this.pLeft = new InputObserver();
            this.pLeft.Attach(new ShipMoveLeftListener());
            this.pRight = new InputObserver();
            this.pRight.Attach(new ShipMoveRightListener());
            this.pSpace = new InputObserver();
            this.pSpace.Attach(new ShipShootListener());
            this.pBoxKey = new InputObserver();
            this.pBoxKey.Attach(new ToggleBoxListener());
            this.pOnePlayer = new InputObserver();
            this.pOnePlayer.Attach(new OnePlayerListener());
            this.pTwoPlayer = new InputObserver();
            this.pTwoPlayer.Attach( new TwoPlayerListener());

            this.spaceIsPressed = false;
            this.boxIsPressed = false;
            this.oneIsPressed = false;
            this.twoIsPressed = false;
        }

        private static InputMan privGetInstance()
        {
            if (pMan == null)
            {
                pMan = new InputMan();
            }
            Debug.Assert(pMan != null);

            return pMan;
        }

        //public static InputObserver MoveRight()
        //{
        //    InputMan pMan = InputMan.privGetInstance();
        //    Debug.Assert(pMan != null);

        //    return pMan.pRight;
        //}

        //public static InputObserver MoveLeft()
        //{
        //    InputMan pMan = InputMan.privGetInstance();
        //    Debug.Assert(pMan != null);

        //    return pMan.pLeft;
        //}

        //public static InputObserver Shoot()
        //{
        //    InputMan pMan = InputMan.privGetInstance();
        //    Debug.Assert(pMan != null);

        //    return pMan.pSpace;
        //}

        //public static InputObserver ToggleBox()
        //{
        //    InputMan pMan = InputMan.privGetInstance();
        //    Debug.Assert(pMan != null);

        //    return pMan.pBoxKey;
        //}
        //public static InputObserver OnePlayer()
        //{
        //    InputMan pMan = InputMan.privGetInstance();
        //    Debug.Assert(pMan != null);

        //    return pMan.pOnePlayer;
        //}
        //public static InputObserver TwoPlayer()
        //{
        //    InputMan pMan = InputMan.privGetInstance();
        //    Debug.Assert(pMan != null);

        //    return pMan.pTwoPlayer;
        //}
        public static void Update()
        {
            InputMan pMan = InputMan.privGetInstance();
            Debug.Assert(pMan != null);

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);

            if (spaceKeyCurr == true && pMan.spaceIsPressed == false)
            {
                pMan.pSpace.Notify();
            }

            pMan.spaceIsPressed = spaceKeyCurr;
            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.pLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.pRight.Notify();
            }

            bool p1 = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1);

            if (p1 == true && pMan.oneIsPressed == false)
            {
                pMan.pOnePlayer.Notify();
            }

            pMan.oneIsPressed = p1;

            bool p2 = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2);

            if (p2 == true && pMan.twoIsPressed == false)
            {
                pMan.pTwoPlayer.Notify();
            }

            pMan.twoIsPressed = p2;

            bool pBox = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T);

            if (pBox == true && pMan.boxIsPressed == false)
            {
                pMan.pBoxKey.Notify();
            }

            pMan.boxIsPressed = pBox;

        }

        // Data: ----------------------------------------------
        private static InputMan pMan = null;
        private bool spaceIsPressed;
        private bool boxIsPressed;
        private bool oneIsPressed;
        private bool twoIsPressed;

        private InputObserver pRight;
        private InputObserver pLeft;
        private InputObserver pSpace;
        private InputObserver pBoxKey;
        private InputObserver pOnePlayer;
        private InputObserver pTwoPlayer;
    }
}
