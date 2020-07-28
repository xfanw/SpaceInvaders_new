using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {

        protected GameObject()
        {

        }
        protected GameObject(GameObject.Name name)
        {
            this.name = name;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = null;
            this.pCollosionObject = null;
        }

        protected GameObject(GameSprite.Name spriteName, GameObject.Name name)
        {
            this.name = name;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = ProxyMan.Add(spriteName);
            this.pCollosionObject = new CollisionObject(pProxySprite);
        }

        ~GameObject()
        {

        }
        virtual public void Set(GameSprite.Name spriteName, GameObject.Name gameName)
        {
            this.pProxySprite.Set(spriteName);
            this.name = gameName;
        }
        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;

            this.pCollosionObject.UpdatePos(pProxySprite);
        }

        public void ActivateCollisionSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.pCollosionObject != null);
            pSpriteBatch.Attach(this.pCollosionObject.pCollsionBoxSprite);
        }
        public void ActivateGameSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.Attach(this.pProxySprite);
        }
        public CollisionObject GetCollisionObject()
        {
            return this.pCollosionObject;
        }
        public ProxySprite GetProxy()
        {
            return this.pProxySprite;
        }

        public Name GetName()
        {
            return this.name;
        }
        // Data: ---------------
        protected Name name;

        public float x;
        public float y;
        protected ProxySprite pProxySprite;
        protected CollisionObject pCollosionObject;


        public enum Name
        {
            R0C0,
            R0C1,
            R0C2,
            R0C3,
            R0C4,
            R0C5,
            R0C6,
            R0C7,
            R0C8,
            R0C9,
            R0C10,

            R1C0,
            R1C1,
            R1C2,
            R1C3,
            R1C4,
            R1C5,
            R1C6,
            R1C7,
            R1C8,
            R1C9,
            R1C10,

            R2C0,
            R2C1,
            R2C2,
            R2C3,
            R2C4,
            R2C5,
            R2C6,
            R2C7,
            R2C8,
            R2C9,
            R2C10,

            R3C0,
            R3C1,
            R3C2,
            R3C3,
            R3C4,
            R3C5,
            R3C6,
            R3C7,
            R3C8,
            R3C9,
            R3C10,

            R4C0,
            R4C1,
            R4C2,
            R4C3,
            R4C4,
            R4C5,
            R4C6,
            R4C7,
            R4C8,
            R4C9,
            R4C10,

            C0,
            C1,
            C2,
            C3,
            C4,
            C5,
            C6,
            C7,
            C8,
            C9,
            C10,

            Aliens_Grid,

            // test
            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,
            MsPacMan,
            PowerUpGhost,
            Prezel,

            BirdGrid,
            BirdColumn_0,
            BirdColumn_1,
            BirdColumn_2,
            //Test

            NullObject,
            Uninitialized
        }
    }
}
