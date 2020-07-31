using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Alien : AlienCategory
    {
        public Alien(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY) : base(spriteName, name)
        {
            this.x = posX;
            this.y = posY;
        }

        ~Alien() { }

        // basic operations
        public override void Update()
        {
            Move();
            base.Update();
        }

        public void Move()
        {
            this.x += Nums.AliensSpeedX;
            if (this.x > 800.0f || this.x < 000.0f)
            {
                Nums.AliensSpeedX *= -1;
            }
        }

        // Visitor + Collision
        public override void Accept(CollisionVisitor other)
        {
            other.VisitAlien(this);
        }
        public override void VisitMissileGroup(MissileGrid g)
        {
            // Alien vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Alien vs Missile
            ColPair.Collide((GameObject)g.GetFirstChild(), this);
        }

        public override void VisitMissile(Missile g)
        {
            // Alien vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());
            g.bHit = true;
            this.Hit(g,this);
            // Missile vs Alien
            Debug.WriteLine("-------> Done  <--------");

        }

        private void Hit(GameObject a, GameObject b)
        {
            Debug.WriteLine("Alien Hit by Missle");
            ColPair pPair = ColPairMan.GetActivePair();
            pPair.SetCollision(a, b);
            pPair.NotifyListeners();
        }
    }
}
