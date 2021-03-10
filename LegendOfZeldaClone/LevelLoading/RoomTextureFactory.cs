﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone.LevelLoading
{
    class RoomTextureFactory
    {
        
        public Texture2D tiles;
        public Texture2D background;
        public Texture2D backgroundFix;
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
            tiles = content.Load<Texture2D>("Background");
            background = content.Load<Texture2D>("Background");
            backgroundFix = content.Load<Texture2D>("BackgroundFix");
        }
    }
}