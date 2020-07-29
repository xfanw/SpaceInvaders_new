using System;
using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class GameSprite : SpriteBase
    {
        public enum Name
        {
            Sprite_Crab,
            Sprite_Squid,
            Sprite_Octopus,
            
            Sprite_Missle,
            Sprite_Ship,
            Sprite_Ship1,
            Sprite_Ship2,
            
            Sprite_Brick,
            Sprite_Brick_LT0,
            Sprite_Brick_LT1,
            Sprite_Brick_RT0,
            Sprite_Brick_RT1,
            Sprite_Brick_LB,
            Sprite_Brick_RB,
            
            Sprite_BombT,
            Sprite_BombZ,
            Sprite_BombC,
            
            Sprite_UFO,
            
            Sprite_AlienDeath,
            Sprite_UFODeath,
            Sprite_ShipDeath,

            Sprite_NullObject,

            // test
            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,
            BlueBird,
            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,
            MsPacMan,
            PowerUpGhost,
            Prezel,
            // test

            uninitialized
        }

        public GameSprite(GameSprite.Name name, Image pImg, Azul.Rect pScr)
        {
            Debug.Assert(pImg != null);
            Debug.Assert(pScr != null);

            // Do the create and load
            this.pImg = pImg;
            this.poAzulSprite = new Azul.Sprite(pImg.GetAzulTexture(), pImg.GetRect(), pScr);
            this.pScrRect = pScr;
            this.name = name;

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        public void SetSprite(GameSprite.Name name, Image pImg, int x, int y, int w, int h)
        {

            this.name = name;

            Debug.Assert(pImg != null);
            this.pImg = pImg;

            Debug.Assert(pScrRect != null);
            pScrRect.Set(x, y, w, h);

            this.poAzulSprite = new Azul.Sprite(pImg.GetAzulTexture(), pImg.GetRect(), pScrRect);
            Debug.Assert(this.poAzulSprite != null);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;

        }

        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            Debug.Assert(this.poAzulSprite != null);
            this.poAzulSprite.SwapColor(_pColor);
        }

        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        {
            //Debug.Assert(this.poAzulColor != null);
            Debug.Assert(GameSprite.psTmpColor != null);
            GameSprite.psTmpColor.Set(red, green, blue, alpha);
            this.poAzulSprite.SwapColor(GameSprite.psTmpColor);
        }

        public void SwapImage(Image pNewImage)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(pNewImage != null);
            this.pImg = pNewImage;

            this.poAzulSprite.SwapTexture(this.pImg.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImg.GetRect());
        }
        override public void Update()
        {
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }
        public void Wash()
        {
            this.name = Name.uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

        }
        override public void Render()
        {
            this.poAzulSprite.Render();
        }
        public GameSprite() : base()
        {
            this.poAzulSprite = new Azul.Sprite();
            Debug.Assert(this.poAzulSprite != null);

            // this.Clear();
        }

        public void SetSpriteName(Name name)
        {
            this.name = name;
        }

        public GameSprite.Name GetName()
        {
            return this.name;
        }

        public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Prev Node
            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            // Next Node
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

        }

        public Azul.Rect GetRect()
        {
            return this.pScrRect;
        }
        // Data: ----------
        public float x;
        public float y;
        private float sx;
        private float sy;
        private float angle;

        private GameSprite.Name name;
        private Image pImg;
        private Azul.Sprite poAzulSprite;
        private Azul.Rect pScrRect = new Azul.Rect();
        //private readonly Azul.Color poAzulColor;


        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);
    }
}
