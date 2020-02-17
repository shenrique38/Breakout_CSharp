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
    public abstract class GameObject
    {

        public string ID;
        public ObjType type;
        public Vector2 position;
        public Vector2 scale;

        public Rectangle rect;
        public Color color;

        public GameObject()
        {
            ID = Guid.NewGuid().ToString();
            this.scale = Vector2.One;
            this.position = new Vector2();
        }

        public virtual void Update()
        { }
        public virtual void KeyPress(SDL.SDL_Keycode keycode)
        {
        }
        public virtual void OnCollision(GameObject other)
        {
           // Console.WriteLine(other.type);
        }

        public Rectangle GetRect()
        {
            int x = (int)(this.position.X - (this.rect.Width / 2f));
            int y = (int)(GameManager.SCREEN_HEIGHT - (this.position.Y + (this.rect.Height / 2f)));
            int w = (int)(rect.Width * scale.X);
            int h = (int)(rect.Height * scale.Y);
            return new Rectangle(x, y, w, h);
        }
        public void Render(IntPtr gRenderer)
        {
           
            SDL.SDL_Rect temp = new SDL.SDL_Rect();
            Rectangle rect = GetRect();
            temp.x = rect.X;
            temp.y = rect.Y;
            temp.w = rect.Width;
            temp.h = rect.Height;

            SDL.SDL_SetRenderDrawColor(gRenderer, color.r, color.g, color.b, 0xFF);
            SDL.SDL_RenderFillRect(gRenderer, ref temp);
        }

        // static world
        public static List<GameObject> gameObjList;
        private static List<GameObject> removePull;

        public static void Init()
        {
            gameObjList = new List<GameObject>();
            removePull = new List<GameObject>();
        }
        public static void RemoveObject(GameObject obj)
        {
            removePull.Add(obj);

        }
        public static void ClearDead()
        {
            foreach (var dead in removePull)
            {
                int index = 0;
                foreach (var item in gameObjList)
                {
                    if(dead.ID == item.ID)
                    {
                        gameObjList.RemoveAt(index);
                        break;
                    }
                    index++;       
                }
            }
            removePull.Clear();
        }
    }
}
