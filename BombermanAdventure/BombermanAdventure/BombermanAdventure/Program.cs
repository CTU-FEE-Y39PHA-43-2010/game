using System;

namespace BombermanAdventure
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Logger.init();
            Logger.Active = true;
            using (GameClass game = new GameClass())
            {
                game.Run();
            }
        }
    }
#endif
}

