﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombermanAdventure.Models;
using BombermanAdventure.Models.GameModels;
using BombermanAdventure.Models.GameModels.Walls;
using BombermanAdventure.Models.GameModels.Players;
using BombermanAdventure.Models.GameModels.Labyrinths;
using Microsoft.Xna.Framework;

namespace BombermanAdventure.Generators
{
    class LevelGenerator
    {
        ModelList models = ModelList.GetInstance();
        public ModelList GenerateLevel(Game game) 
        {
            models.Labyrinth = new Labyrinth(game, 8, 8);
            
            models.AddWall(new BrickWall(game, 0, 0));
            models.AddWall(new BrickWall(game, 1, 2));
            models.AddWall(new BrickWall(game, 2, 5));
            models.AddWall(new BrickWall(game, 3, 8));
            models.AddWall(new BrickWall(game, 4, 0));
            models.AddWall(new BrickWall(game, -5, -2));
            models.AddWall(new BrickWall(game, 2, 7));
            models.AddWall(new BrickWall(game, 2, 6));
            models.AddWall(new BrickWall(game, 8, 0));
            models.AddWall(new BrickWall(game, -7, 4));
            models.AddWall(new BrickWall(game, 3, -4));

            models.Player = new Player(game, 8, 8);

            return models;
        }
    }
}
