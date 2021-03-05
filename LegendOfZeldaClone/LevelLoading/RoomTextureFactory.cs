﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone.LevelLoading
{
    class RoomTextureFactory
    {
        // Public problem
        public Texture2D tiles;
        public Texture2D roomExterior;
        public Texture2D background;
        private static RoomTextureFactory instance = new RoomTextureFactory();
        
        public static RoomTextureFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private RoomTextureFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            tiles = content.Load<Texture2D>("WallsDoorBackground");
            roomExterior = content.Load<Texture2D>("LevelLoading\\RoomExterior");
            background = content.Load<Texture2D>("Background");
        }
    }
}
