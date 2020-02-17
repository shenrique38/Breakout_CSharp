using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using System.Numerics;

namespace My_SDL
{
    public class Block : GameObject
    {

        public Block(Color color) : base()
        {
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = 40;
            this.rect.Height = 20;


            this.color = color;
            this.type = ObjType.Block;
            this.position = new Vector2();
            this.scale = Vector2.One;
        }

        public override void OnCollision(GameObject other)
        {
            if (other.type == ObjType.GoldBall)
                GameObject.RemoveObject(this);
        }

        public override void Update()
        {
            //this.position.X += 0.01f;
            //this.position.Y += 0.01f;
        }
    }
}
