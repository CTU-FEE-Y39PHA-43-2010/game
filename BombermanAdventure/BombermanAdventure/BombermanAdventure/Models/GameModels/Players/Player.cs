﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BombermanAdventure.Models.GameModels.Bombs;

namespace BombermanAdventure.Models.GameModels.Players
{
    class Player : AbstractGameModel
    {
        enum Bombs { COMMON, WATER, MUD, ELECTRIC }

        Bombs selectedBombType;
        KeyboardState oldState;
        Game game;

        int possibleBombsCount;
        int bombsCount;
        int bombRange;
        int life;

        public int Life 
        {
            get { return life; }
        }

        public int BombRange 
        {
            get { return bombRange; }
        }


        public Player(Game game) : base(game) 
        {
            this.game = game;
        }

        public override void Initialize()
        {   
            base.modelName = "Models/Player";
            base.modelScale = 0.1f;
            
            modelPosition = new Vector3(0, 0, 0);
            modelRotation = new Vector3();

            life = 100;

            selectedBombType = Bombs.COMMON;
            possibleBombsCount = 3;
            bombsCount = 0;
            bombRange = 3;
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            KeyBoardHandler(gameTime);
            base.Update(gameTime);
        }

        public override void OnEvent(Events.CommonEvent ieEvent)
        {
            if (ieEvent is Events.Bombs.AbstractBombExplosionEvent)
            {
                Events.Bombs.AbstractBombExplosionEvent leEvent = (Events.Bombs.AbstractBombExplosionEvent)ieEvent;
                if (leEvent.Player == this)
                {
                    bombsCount--;
                }
            }
        }

        #region Ovladani

        private void KeyBoardHandler(GameTime gameTime)
        {
            switch(Cameras.Camera.position) 
            {
                case Cameras.Camera.Position.FRONT:
                    this.Front();
                    break;
                case Cameras.Camera.Position.LEFT:
                    this.Left();
                    break;
                case Cameras.Camera.Position.BACK:
                    this.Back();
                    break;
                case Cameras.Camera.Position.RIGHT:
                    this.Right();
                    break;
            }
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Space))
            {
                if (!oldState.IsKeyDown(Keys.Space)) 
                {
                    this.PutBomb(gameTime);
                }
            }
            if (ks.IsKeyDown(Keys.LeftControl))
            {
                if (!oldState.IsKeyDown(Keys.LeftControl))
                {
                    this.ChageBombType(gameTime);
                }
            }
            oldState = ks;
        }

        private void ChageBombType(GameTime gameTime) 
        {
            switch (selectedBombType)
            {
                case Bombs.COMMON:
                    selectedBombType = Bombs.WATER;
                    break;
                case Bombs.WATER:
                    selectedBombType = Bombs.ELECTRIC;
                    break;
                case Bombs.ELECTRIC:
                    selectedBombType = Bombs.MUD;
                    break;
                case Bombs.MUD:
                    selectedBombType = Bombs.COMMON;
                    break;
            }
        }

        private void PutBomb(GameTime gameTime) 
        {
            if (bombsCount < possibleBombsCount) 
            {
                switch (selectedBombType) 
                {
                    case Bombs.COMMON:
                        base.models.Add(new CommonBomb(game, modelPosition, this, gameTime));
                        break;
                    case Bombs.WATER:
                        base.models.Add(new WaterBomb(game, modelPosition, this, gameTime));
                        break;
                    case Bombs.ELECTRIC:
                        base.models.Add(new ElectricBomb(game, modelPosition, this, gameTime));
                        break;
                    case Bombs.MUD:
                        base.models.Add(new MudBomb(game, modelPosition, this, gameTime));
                        break;
                }
                bombsCount++;
            }
        }

        #region Ovladani Chuze
        private void Front() 
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                modelPosition.Z -= 2;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                modelPosition.Z += 2;
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                modelPosition.X -= 2;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                modelPosition.X += 2;
            }
        }

        private void Left() 
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                modelPosition.X -= 2;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                modelPosition.X += 2;
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                modelPosition.Z += 2;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                modelPosition.Z -= 2;
            }
        }

        private void Back() 
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                modelPosition.Z += 2;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                modelPosition.Z -= 2;
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                modelPosition.X += 2;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                modelPosition.X -= 2;
            }
        }

        private void Right() 
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Right))
            {
                modelPosition.X += 2;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                modelPosition.X -= 2;
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                modelPosition.Z -= 2;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                modelPosition.Z += 2;
            }
        }
#endregion
#endregion
    }
}
