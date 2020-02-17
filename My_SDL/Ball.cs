using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace My_SDL
{
    class Ball : GameObject
    {
        Vector2 direction;
        float speed = 2.5f;
        TimeSpan lastColl;

        public Ball() : base()
        {
            this.type = ObjType.GoldBall;

            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = 10;
            this.rect.Height = 10;

            this.color = Color.Yellow();

            direction = Vec.Down();

        }

        public override void OnCollision(GameObject other)
        {
            if( (DateTime.Now.TimeOfDay -  lastColl).TotalMilliseconds < 8)
            {
                return;
            }
            lastColl = DateTime.Now.TimeOfDay;

            switch (other.type)
            {
                case ObjType.Block:
                    BlockCollosion(other);
                    break;
                case ObjType.PlayerPad:
                    PlayerPadCollision(other);
                    break;
                case ObjType.Border:
                    Boarders bd = (Boarders)other;
                    switch (bd.side)
                    {
                        case Side.Left:
                            direction = Vector2.Reflect(direction, Vec.Right());
                            break;
                        case Side.Right:
                            direction = Vector2.Reflect(direction, Vec.Left());
                            break;
                        case Side.Bottom:
                            direction = Vector2.Reflect(direction, Vec.Up());
                            break;
                        case Side.Top:
                            direction = Vector2.Reflect(direction, Vec.Down());
                            break;
                    }
                    break;
            }
        }

        public void PlayerPadCollision(GameObject other)
        {
            Rectangle rect = other.GetRect();
            float Arc = 50;
            float pos = this.position.X - rect.X;
            float halfW = rect.Width / 2f;
            float hitAngle;
            float convAng;
            double rad;

            if (pos > halfW)
            {
                //right
                hitAngle = (pos - halfW) / halfW;
                convAng = 90 - (Arc * hitAngle);

                rad = Math.PI * convAng / 180.0;
                direction.X = (float)Math.Cos(rad);
                direction.Y = (float)Math.Sin(rad);
            }
            else if (pos < halfW)
            {
                //left
                hitAngle = (halfW - pos) / halfW;
                convAng = 90 + (Arc * hitAngle);

                rad = Math.PI * convAng / 180.0;
                direction.X = (float)Math.Cos(rad);
                direction.Y = (float)Math.Sin(rad);
            }
            else
            {
                direction = Vec.Up();
            }
        }
        public void BlockCollosion(GameObject other)
        {
            Rectangle rect = other.GetRect();
            int bottomPoint = rect.Y - rect.Height;

            if (this.position.X < rect.X && this.position.Y < rect.Y)
            {
                //left
                direction = Vector2.Reflect(direction, Vec.Left());
            }
            else if (this.position.X > rect.X && this.position.Y > rect.Y)
            {
                //top
                direction = Vector2.Reflect(direction, Vec.Up());
            }
            else if(this.position.Y > bottomPoint)
            {
                //right
                direction = Vector2.Reflect(direction, Vec.Right());
            }
            else
            {
                direction = Vector2.Reflect(direction, Vec.Down());
            }
        

        }
        public override void Update()
        {
            direction = Vector2.Normalize(direction);
            this.position += direction * speed * GameManager.DeltaTime;
        }
    }
}
