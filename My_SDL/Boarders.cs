using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace My_SDL
{
   public enum Side
    {
        Left,
        Right,
        Bottom,
        Top,
    }

    class Boarders : GameObject
    {
        public Side side;

        public Boarders(Side side) : base()
        {
            this.type = ObjType.Border;
            this.side = side;
            this.color = Color.Green();
            int length = 10;
            int pad = 13;

            switch (side)
            {
                case Side.Left:
                    rect.X = 0;
                    rect.Y = 0;
                    rect.Width = length;
                    rect.Height = GameManager.SCREEN_HEIGHT - pad;

                    this.position.Y = GameManager.SCREEN_HEIGHT / 2;         
                    break;
                case Side.Right:
                    rect.X = 0;
                    rect.Y = 0;
                    rect.Width = length;
                    rect.Height = GameManager.SCREEN_HEIGHT - pad;

                    this.position.Y = GameManager.SCREEN_HEIGHT / 2;
                    this.position.X = GameManager.SCREEN_WIDTH ;
                    break;
                case Side.Bottom:
                    rect.X = 0;
                    rect.Y = 0;
                    rect.Width = GameManager.SCREEN_WIDTH - pad;
                    rect.Height = length;

                    this.position.X = GameManager.SCREEN_WIDTH / 2;

                    break;
                case Side.Top:
                    rect.X = 0;
                    rect.Y = 0;
                    rect.Width = GameManager.SCREEN_WIDTH - pad;
                    rect.Height = length;

                    this.position.X = (GameManager.SCREEN_WIDTH / 2);
                    this.position.Y = GameManager.SCREEN_HEIGHT;
                    break;
            }
        }
    }
}
