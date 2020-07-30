using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    //---------------------------------------------------------------------------------------------------------
    // Design Notes:
    //---------------------------------------------------------------------------------------------------------

    public class ProxySprite : SpriteBase
    {

        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------

        // Create a single sprite and all dynamic objects ONCE and ONLY ONCE (OOO- tm)
        public ProxySprite()
            : base()
        {

            this.x = 1.0f;
            this.y = 1.0f;

            this.pSprite = null;
        }

        ~ProxySprite()
        {

        }

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------

        public ProxySprite(GameSprite.Name name)
        {
            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public void Set(GameSprite.Name name)
        {
            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public override void Update()
        {

        }

        public void Wash()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.pSprite = null;
            // Wash - clear the entire hierarchy
            base.Clear();            
        }



        public override void Render()
        {
            Debug.Assert(this.pSprite != null);

            pSprite.x = this.x;
            pSprite.y = this.y;

            // update and draw real sprite 
            // Seems redundant - Real Sprite might be stale
            this.pSprite.Update();
            this.pSprite.Render();
        }
        
        public GameSprite.Name GetName()
        {
            return this.pSprite.GetName();
        }

        public Azul.Rect GetSpriteRect()
        {
            return this.pSprite.GetRect();
        }


        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------

        public float x;
        public float y;
        private GameSprite pSprite;
    }
}
