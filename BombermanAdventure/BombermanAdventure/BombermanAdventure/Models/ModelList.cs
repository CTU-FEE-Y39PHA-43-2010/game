using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BombermanAdventure.Cameras;
using BombermanAdventure.Models.GameModels;
using BombermanAdventure.Models.GameModels.Players;
using BombermanAdventure.Events;

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
        /// modely k vykresleni
        /// </summary>
        List<AbstractGameModel> models;
        public List<AbstractGameModel> Models 
        {
            get { return models; }
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


        private ModelList() 
        {
            models = new List<AbstractGameModel>();
        }

        public static ModelList GetInstance() 
        {
            if (instance == null)
                instance = new ModelList();
            return instance;
        }

        public void Add(AbstractGameModel imModel) 
        {
            models.Add(imModel);
        }

        public void RegisterEvent(CommonEvent ieEvent) 
        {
            if (ieEvent is IDestructible)
            {
                models.Remove(ieEvent.Model);
            }
            foreach (AbstractGameModel lmModel in models)
            {
                    lmModel.OnEvent(ieEvent);
            }
            player.OnEvent(ieEvent);
           
        }
    }
}
