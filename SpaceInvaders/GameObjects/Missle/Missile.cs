﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpaceInvaders
{
    public class Missile : MissileCategory
    {
        public Missile(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY) : base(spriteName, name)
        {
            this.x = posX;
            this.y = posY;
            this.orgY = posY;
            this.bHit = false;
        }

        ~Missile() { }

        public override void Update()
        {
            Move();
            base.Update();
        }

        public void Move()
        {
            if (!bHit)
            {
                this.y += Nums.MissleSpeedY;
            } else
            {
                this.Reset();
            }
        }

        public void Reset()
        {
            this.y = orgY;
            this.bHit = false;
        }
        // Visitor + Collision
        public override void Accept(CollisionVisitor other)
        {
            other.VisitMissile(this);
        }

        public override void VisitAlienGrid(AliensGrid g)
        {
            // Missile vs AliensGrid 
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Missile vs AliensCol
            ColPair.Collide((GameObject)g.GetFirstChild(), this);
        }

        public override void VisitAlienColumn(AliensColumn c)
        {
            // AliensCol vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", c.GetName(), this.GetName());

            // Missile vs AliensCol
            ColPair.Collide((GameObject)this.GetFirstChild(), this);
        }
        public override void VisitAlien(Alien a)
        {
            // Aliens vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", a.GetName(), this.GetName());

            // Missile vs Alien
            Debug.WriteLine("-------> Done  <--------");

            a.VisitMissile(this);
        }

        public bool bHit;
        private float orgY = 0.0f;
    }
}
