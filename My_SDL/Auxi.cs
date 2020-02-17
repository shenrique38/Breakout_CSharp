using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using SDL2;
using System.Drawing;
using System.Runtime.InteropServices;

namespace My_SDL
{
    public enum ObjType
    {
        Block,
        PlayerPad,
        GoldBall,
        Border,
    }

    public struct Color  //representa uma cor
    {
        public byte r; //red
        public byte g; //green
        public byte b; //blue

        Color(byte red, byte green, byte blue)
        {
            r = red;
            g = green;
            b = blue;
        }

        public static Color Red()
        {
            return new Color(255, 0, 0);
        }
        public static Color Blue()
        {
            return new Color(0, 0, 255);
        }
        public static Color Green()
        {
            return new Color(0, 255, 0);
        }
        public static Color White()
        {
            return new Color(255, 255, 255);
        }
        public static Color Black()
        {
            return new Color(0, 0, 0);
        }
        public static Color Aqua()
        {
            return new Color(0, 255, 255);
        }
        public static Color Pink()
        {
            return new Color(255, 0, 255);
        }
        public static Color Yellow()
        {
            return new Color(255, 255, 0);
        }
    };


    public class LTexture
    {
        Rectangle rect;
        IntPtr mTexture;
        IntPtr gRenderer;

        //Image dimensions
        public int mWidth;
        public int mHeight;

        public LTexture(IntPtr gRenderer)
        {
            this.gRenderer = gRenderer;
            this.mTexture = new IntPtr();
            mWidth = 0;
            mHeight = 0;
        }

        //Loads image at specified path
        public bool LoadFromFile(string path)
        {
            SDL.SDL_Surface sd;
            //Load image at specified path
            mTexture = SDL_image.IMG_LoadTexture(gRenderer, path);

            //sd = (SDL.SDL_Surface)Marshal.PtrToStructure(loadedSurface, typeof(SDL.SDL_Surface));


            //  SDL.SDL_SetColorKey(loadedSurface, true, SDL_MapRGB(loadedSurface->format, 0, 0xFF, 0xFF));

            // newTexture = SDL.SDL_CreateTextureFromSurface(gRenderer, loadedSurface);

            //mWidth = sd.w;
            // mHeight = sd.h;

            return true;
        }
        public void Render(int x, int y)
        {
            SDL.SDL_Rect renderQuad = new SDL.SDL_Rect();
            renderQuad.x = x;
            renderQuad.y = y;
            renderQuad.w = mWidth;
            renderQuad.h = mHeight;
            IntPtr NULL = IntPtr.Zero;
            SDL.SDL_RenderCopy(gRenderer, mTexture, NULL, IntPtr.Zero);
        }
    };

    public static class Vec
    {
        public static Vector2 Up()
        {
            return new Vector2(0, 1);
        }
        public static Vector2 Down()
        {
            return new Vector2(0, -1);
        }
        public static Vector2 Left()
        {
            return new Vector2(-1, 0);
        }
        public static Vector2 Right()
        {
            return new Vector2(1, 0);
        }
    }

};

