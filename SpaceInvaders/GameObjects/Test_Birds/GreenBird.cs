using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GreenBird : BirdCategory
    {
        public GreenBird(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY)
    : base(spriteName, name)
        {
            this.x = posX;
            this.y = posY;
            this.speed = 1.0f;
        }

        // Data: ---------------
        ~GreenBird()
        {

        }

        public override void Update()
        {
            Move();
            base.Update();
        }

        public void Move()
        {
            this.y += speed;
            if (this.y > 600.0f || this.y < 300.0f)
            {
                speed *= -1;
            }
        }

        public override void Accept(CollisionVisitor other)
        {
            throw new NotImplementedException();
        }
        // this is just a placeholder, who knows what data will be stored here

    }
}
