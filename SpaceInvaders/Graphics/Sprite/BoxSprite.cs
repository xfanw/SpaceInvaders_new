using System.Diagnostics;


namespace SpaceInvaders
{
    public class BoxSprite : SpriteBase
    {

        public BoxSprite() : base()
        {
            //SetUpTrick();

            Debug.Assert(BoxSprite.psTmpRect != null);
            BoxSprite.psTmpRect.Set(0, 0, 1, 1);
            Debug.Assert(BoxSprite.psTmpColor != null);
            BoxSprite.psTmpColor.Set(1, 1, 1);


            // Here is the actual new
            this.pBox= new Azul.SpriteBox(psTmpRect, psTmpColor);
            Debug.Assert(this.pBox!= null);

            // Here is the actual new
            this.pColor= new Azul.Color(1, 1, 1);
            Debug.Assert(this.pColor!= null);

            this.x = pBox.x;
            this.y = pBox.y;
            this.sx = pBox.sx;
            this.sy = pBox.sy;
            this.angle = pBox.angle;
        }

        //private static void SetUpTrick()
        //{
        //    Debug.Assert(BoxSprite.psTmpRect != null);
        //    BoxSprite.psTmpRect.Set(0, 0, 1, 1);
        //    Debug.Assert(BoxSprite.psTmpColor != null);
        //    BoxSprite.psTmpColor.Set(1, 1, 1);
        //}

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void Set(float x, float y, float width, float height, Azul.Color pLineColor)
        {
            Debug.Assert(this.pBox != null);
            Debug.Assert(this.pColor != null);

            Debug.Assert(psTmpRect != null);
            BoxSprite.psTmpRect.Set(x, y, width, height);

            if (pLineColor == null)
            {
                this.pColor.Set(1, 1, 1);
            }
            else
            {
                this.pColor.Set(pLineColor);
            }

            this.pBox.Swap(psTmpRect, this.pColor);

            this.x = pBox.x;
            this.y = pBox.y;
            this.sx = pBox.sx;
            this.sy = pBox.sy;
            this.angle = pBox.angle;
        }

        public void SetScreenRect(float x, float y, float w, float h)
        {
            Set(x, y, w, h, this.pColor);

        } 

        public void SetLineColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.pColor != null);
            this.pColor.Set(red, green, blue, alpha);
        }
        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            this.pBox.SwapColor(_pColor);
        }
        public void Wash()
        {
            // NOTE:
            // Do not null the poAzulBoxSprite it is created once in Default then reused
            // Do not null the poLineColor it is created once in Default then reused

            this.pColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void Dump()
        {
            // Dump - Print contents to the debug output window
            //        Using HASH code as its unique identifier 
            Debug.WriteLine("   Name: ({0})", this.GetHashCode());
            Debug.WriteLine("      Color(r,b,g): {0},{1},{2} ({3})", this.pColor.red, this.pColor.green, this.pColor.blue, this.pColor.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.pBox.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);

            if (this.pNext == null)
            {
                Debug.WriteLine("              next: null");
            }
            else
            {
                BoxSprite pTmp = (BoxSprite)this.pNext;
                Debug.WriteLine("              next:  ({0})", pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("              prev: null");
            }
            else
            {
                BoxSprite pTmp = (BoxSprite)this.pPrev;
                Debug.WriteLine("              prev: {0} ", pTmp.GetHashCode());
            }
        }
        public override void Render()
        {
            this.pBox.Render();
        }

        public override void Update()
        {
            this.pBox.x = this.x;
            this.pBox.y = this.y;
            this.pBox.sx = this.sx;
            this.pBox.sy = this.sy;
            this.pBox.angle = this.angle;

            this.pBox.Update();
        }

        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private float x;
        private float y;
        private float sx;
        private float sy;
        private float angle;

        private Azul.Color pColor;
        private Azul.SpriteBox pBox;

        //---------------------------------------------------------------------------------------------------------
        // Static Data - prevent unecessary "new" in the above methods
        //---------------------------------------------------------------------------------------------------------
        static private Azul.Rect psTmpRect = new Azul.Rect(0, 0, 1, 1);
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);
    }
}
