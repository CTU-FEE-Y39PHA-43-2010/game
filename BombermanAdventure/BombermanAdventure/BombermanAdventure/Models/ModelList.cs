﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BombermanAdventure.Cameras;
using BombermanAdventure.Models.GameModels;
using BombermanAdventure.Models.GameModels.Bombs;
using BombermanAdventure.Models.GameModels.Walls;
using BombermanAdventure.Models.GameModels.Players;
using BombermanAdventure.Models.GameModels.Labyrinths;
using BombermanAdventure.Events;
using BombermanAdventure.Events.Bombs;
using BombermanAdventure.Events.Collisions;

namespace BombermanAdventure.Models
{
    class ModelList
    {
        /// <summary>
        /// instance k modelListu pro vytvoreni jedinacka
        /// </summary>
        static ModelList instance = null;

        /// <summary>
        /// Lidský hráč
        /// </summary>
        Player player;
        public Player Player 
        {
            get { return player; }
            set 
            {
                if (player == null)
                {
                    player = value;
                } 
            }
        }

        /// <summary>
        /// Camera sceny
        /// </summary>
        Camera camera;
        public Camera Camera
        {
            get { return camera; }
            set 
            {
                if (camera == null)
                {
                    camera = value;
                }
            }
        }

        /// <summary>
        /// Head-Up Display
        /// </summary>
        HUD hud;
        public HUD Hud 
        {
            get { return hud; }
            set 
            {
                if (hud == null) 
                {
                    hud = value;
                }
            }
        }

        /// <summary>
        /// model labyrintu
        /// </summary>
        Labyrinth labyrinth;
        public Labyrinth Labyrinth 
        {
            get { return labyrinth; }
            set 
            {
                if (labyrinth == null) 
                {
                    labyrinth = value;
                }
            }
        }

        /// <summary>
        /// modely bomb
        /// </summary>
        List<AbstractBomb> bombs;
        public List<AbstractBomb> Bombs 
        {
            get { return bombs; }
        }

        /// <summary>
        /// modely zdi
        /// </summary>
        List<AbstractWall> walls;
        public List<AbstractWall> Walls 
        {
            get { return walls; }
        }


        private ModelList() 
        {
            bombs = new List<AbstractBomb>();
            walls = new List<AbstractWall>();
        }

        public static ModelList GetInstance() 
        {
            if (instance == null)
                instance = new ModelList();
            return instance;
        }
        
        public void AddBomb(AbstractBomb bomb)
        {
            bombs.Add(bomb);
        }

        public void AddWall(AbstractWall wall)
        {
            walls.Add(wall);
        }

        public void RegisterEvent(CommonEvent ieEvent) 
        {
            if (ieEvent is AbstractBombExplosionEvent)
            {
                AbstractBomb bomb = (AbstractBomb)ieEvent.Model;
                player.OnEvent(ieEvent);
                bombs.Remove(bomb);
            }
            else
            {
                player.OnEvent(ieEvent);
            }
           
        }

        /// <summary>
        /// metoda pro kontrolovani kolizi lidskeho hrace
        /// </summary>
        void CheckForHumanPlayerCollisions()
        {
            foreach (LabyrinthBlock block in labyrinth.Blocks)
            {
                if (player.BoundingSphere.Intersects(block.BoundingBox))
                {
                    block.ChangeColor(new Vector3(0f, 1f, 0f));
                    player.OnEvent(new CollisionEvent(player, block));
                    return;
                }
            }

            foreach (AbstractWall wall in walls) 
            {
                if (player.BoundingSphere.Intersects(wall.BoundingBox)) 
                {
                    player.OnEvent(new CollisionEvent(player, wall));
                    return;
                }
            }
            foreach (AbstractBomb bomb in bombs) 
            {
                if (player.BoundingSphere.Intersects(bomb.BoundingSphere) && bomb.isCollidable) 
                {
                    player.OnEvent(new CollisionEvent(player, bomb));
                    return;
                }
            }
        }

        public void Update(GameTime gameTime) 
        {
            List<AbstractGameModel> modelsList = new List<AbstractGameModel>();
            foreach (AbstractBomb bomb in bombs)
            {
                modelsList.Add(bomb);
            }

            foreach (AbstractWall wall in walls)
            {
                modelsList.Add(wall);
            }

            
            foreach (AbstractGameModel model in modelsList)
            {
                model.Update(gameTime);
            }

            labyrinth.Update(gameTime);
            player.Update(gameTime);
            hud.Update(gameTime);
            CheckForHumanPlayerCollisions();
        }

        public void DrawModels(GameTime gameTime) 
        {
           /* GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);
            //GraphicsDevice.BlendState = BlendState.AlphaBlend;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            foreach (AbstractGameModel model in models.Models)
            {
                model.Draw(gameTime);
            }
            models.Player.Draw(gameTime);

            GraphicsDevice.DepthStencilState = DepthStencilState.None;
            models.Hud.Draw(gameTime);*/
        }

        public void DrawBackground(GameTime gameTime) 
        {

        }

        public void DrawLabyrinth(GameTime gameTime) 
        {
            labyrinth.Draw(gameTime);
        }

        public void DrawWalls(GameTime gameTime) 
        {
            foreach (AbstractWall wall in walls) 
            {
                wall.Draw(gameTime);
            }
        }

        public void DrawBonusesAndGuns(GameTime gameTime) 
        {

        }

        public void DrawBombs(GameTime gameTime) 
        {
            foreach (AbstractBomb bomb in bombs) 
            {
                bomb.Draw(gameTime);
            }
        }

        public void DrawExplosions(GameTime gameTime) 
        {

        }

        public void DrawShots(GameTime gameTime) 
        {

        }

        public void DrawPlayer(GameTime gameTime) 
        {
            player.Draw(gameTime);
        }

        public void DrawEnemies(GameTime gameTime) 
        {

        }

        public void DrawHUD(GameTime gameTime) 
        {
            hud.Draw(gameTime);
        }

    }
}
