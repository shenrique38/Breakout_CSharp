using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using System.Numerics;
using System.Drawing;

namespace My_SDL
{
    public class PlayerPad : GameObject
    {
        float speed = 20;

        public PlayerPad() : base()
        {
            this.rect.X = 0;
            this.rect.Y = 0;
            this.rect.Width = 120;
            this.rect.Height = 20;

            this.color = Color.Pink();
            this.type = ObjType.PlayerPad;
            this.position = new Vector2();
            this.scale = Vector2.One;

            this.position.X = GameManager.SCREEN_WIDTH / 2;
            this.position.Y = 20;
        }

        public override void KeyPress(SDL.SDL_Keycode keycode)
        {
            Rectangle rect;
            switch (keycode)
            {
                case SDL.SDL_Keycode.SDLK_RIGHT:

                    rect = GetRect();
                    if ((rect.Width + rect.X) < GameManager.SCREEN_WIDTH)
                        this.position.X += speed;
                    break;
                case SDL.SDL_Keycode.SDLK_LEFT:

                    rect = GetRect();
                    if (rect.X > 0)
                        this.position.X -= speed;
                    break;
            }
        }

        public override void Update()
        {

        }
    }
}
