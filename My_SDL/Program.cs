using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using System.Drawing;
using System.Numerics;

namespace My_SDL
{

    class Program
    {
        static bool quit = false;

        //The window we'll be rendering to
        static IntPtr gWindow;
        static IntPtr gRenderer;

        static bool Init()
        {
            //Initialization flag
            bool success = true;

            //Initialize SDL
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                success = false;
            }
            else
            {
                //Create window
                gWindow = SDL.SDL_CreateWindow("Breakout C#", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, GameManager.SCREEN_WIDTH, GameManager.SCREEN_HEIGHT, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

                //Create renderer for window
                gRenderer = SDL.SDL_CreateRenderer(gWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

                Color cl = Color.Black();

                //Initialize renderer color
                SDL.SDL_SetRenderDrawColor(gRenderer, cl.r, cl.g, cl.b, 0xFF);

                

                GameObject.Init();
            }

            return success;
        }
        static void Draw()
        {
            //Clear screen
            Color cl = Color.Black();
            SDL.SDL_SetRenderDrawColor(gRenderer, cl.r, cl.g, cl.b, 0xFF);

            SDL.SDL_RenderClear(gRenderer);

            for (int i = 0; i < GameObject.gameObjList.Count; i++)
            {
                GameObject.gameObjList[i].Render(gRenderer);
            }

            //Update screen
            SDL.SDL_RenderPresent(gRenderer);

        }
        static void Update()
        {
            for (int i = 0; i < GameObject.gameObjList.Count; i++)
            {
                GameObject.gameObjList[i].Update();
            }
        }
        static void PullCheck()
        {
            SDL.SDL_Event e;
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        quit = true;
                        break;
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        foreach (var item in GameObject.gameObjList)
                        {
                            item.KeyPress(e.key.keysym.sym);
                        }
                        break;
                }
            }

        }
        static void Collision()
        {
            for (int i = 0; i < GameObject.gameObjList.Count; i++)
            {
                for (int j = 0; j < GameObject.gameObjList.Count; j++)
                {
                    if (GameObject.gameObjList[i].ID != GameObject.gameObjList[j].ID)
                    {
                        Rectangle result = Rectangle.Intersect(GameObject.gameObjList[i].GetRect(), GameObject.gameObjList[j].GetRect());
                        if (!result.IsEmpty)
                            GameObject.gameObjList[j].OnCollision(GameObject.gameObjList[i]);
                    }
                }
            }
        }

        static IntPtr texture;

        static void Main(string[] args)
        {
            Init();
            GameManager.StartGame();

         
            double last = DateTime.Now.TimeOfDay.TotalMilliseconds;

            TimeSpan time = DateTime.Now.TimeOfDay;
            int frameCount = 0;

            while (!quit)
            {
                if ((DateTime.Now.TimeOfDay - time).Seconds > 1)
                {
                    GameManager.FrameRate = frameCount;
                    frameCount = 0;
                    time = DateTime.Now.TimeOfDay;
                }

                double delta = (DateTime.Now.TimeOfDay.TotalMilliseconds - last) * 10000000 / DateTime.Now.TimeOfDay.TotalMilliseconds;
                GameManager.DeltaTime = (float)delta;
                last = DateTime.Now.TimeOfDay.TotalMilliseconds;

                PullCheck();
                Update();
                Collision();
                GameObject.ClearDead();
                Draw();

                frameCount++;     
            }

            return;
        }
    }
}
