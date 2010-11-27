using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombermanAdventure.Models;
using BombermanAdventure.Models.GameModels;
using BombermanAdventure.Models.GameModels.Walls;
using BombermanAdventure.Models.GameModels.Players;
using Microsoft.Xna.Framework;

namespace BombermanAdventure.Generators
{
    static class LevelGenerator
    {
        static ModelList models = ModelList.GetInstance();
        public static ModelList GenerateLevel(Game game) 
        {
            //List<AbstractGameModel> models = new List<AbstractGameModel>();

            models.Add(new Ground(game));
            //models.Add(new BrickWall(game, new Vector3(0, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(20, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(40, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(60, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(80, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(100, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(120, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(140, 0, 0)));
            //models.Add(new BrickWall(game, new Vector3(160, 0, 0)));
            
            models.Add(new BrickWall(game, new Vector3(200, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(180, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(160, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(140, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(120, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(100, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(80, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(60, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(40, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(20, 0, 0)));
            models.Add(new BrickWall(game, new Vector3(0, 0, 0)));


            models.Player = new Player(game);

            return models;
        }
    }
}
