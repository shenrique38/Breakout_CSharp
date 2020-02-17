using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace My_SDL
{
    public static class GameManager
    {
        public const int SCREEN_WIDTH = 800;
        public const int SCREEN_HEIGHT = 600;


        public const int blockW = 40;
        public const int blockH = 20;

        public static int Score;
        public static int lives;
        public static int FrameRate;
        public static float DeltaTime;

        public static void StartGame()
        {
            Score = 0;
            lives = 3;

            SpawnBorders();
            SpawnPlayerPad();
            SpawnLevel1Blocks();
            SpawnGoldenBall();
        }
        public static void AddPoint()
        {
            Score += 1;
        }
        public static void RemoveLive()
        {
            lives -= 1;
        }

        static void SpawnBorders()
        {
            Boarders bTop = new Boarders(Side.Top);
            Boarders bLeft = new Boarders(Side.Left);

            Boarders bBottom = new Boarders(Side.Bottom);
            Boarders bRight = new Boarders(Side.Right);

            GameObject.gameObjList.Add(bLeft);
            GameObject.gameObjList.Add(bTop);
            GameObject.gameObjList.Add(bBottom);
            GameObject.gameObjList.Add(bRight);

        }
        static void SpawnPlayerPad()
        {
            PlayerPad player = new PlayerPad();
            GameObject.gameObjList.Add(player);
        }
        static void SpawnGoldenBall()
        {
            Ball ball = new Ball();
            GameObject.gameObjList.Add(ball);
            ball.position = new Vector2(GameManager.SCREEN_WIDTH / 2, GameManager.SCREEN_HEIGHT / 2);
        }

        static void SpawnLevel1Blocks()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Block block = new Block(Color.Red());
                    block.position.X = j*50 + 110;
                    block.position.Y = (SCREEN_HEIGHT - 50) - (i * 30);

                    GameObject.gameObjList.Add(block);
                }
            }
        }

        
    }
}
