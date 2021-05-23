using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NourishMeant
{
    /* Boiler plate code for GameState management obtained from https://rareelementgames.wordpress.com/2017/04/21/game-state-management/*/
    interface IGameState
    {
        // Initialize the game settings here
       void Initialize();

        // Load all content here
        void LoadContent(ContentManager content);

        // Unload any content here
        void UnloadContent();

        // Updates the game
        void Update(GameTime gameTime);

        // Draws the game
        void Draw(SpriteBatch spriteBatch);
    }
}