using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NourishMeant
{
    /* Boiler plate code for GameState management obtained from https://rareelementgames.wordpress.com/2017/04/21/game-state-management/*/
    public abstract class GameState : IGameState
    {
         protected GraphicsDevice _graphicsDevice;
      public GameState(GraphicsDevice graphicsDevice)
      {
          _graphicsDevice = graphicsDevice;
      }

        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);

        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}