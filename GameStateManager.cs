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
    class GameStateManager
    {
        // Instance of the game state manager
        private static GameStateManager _instance;
        private ContentManager _content;

        // Stack for the screens     
        private Stack<GameState> _screens = new Stack<GameState>();

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStateManager();
                }
                return _instance;
            }
        }

        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        public void AddNewScreen(GameState Screen)
        {
            try
            {
                _screens.Push(Screen);

                _screens.Peek().Initialize();

                if(_content != null)
                {
                    _screens.Peek().LoadContent(_content);
                }
            }
            catch(Exception e)
            {

            }
            
            

        }

        //clears all screens from the stack
        public void ClearScreens()
        {
            while (_screens.Count > 0)
            {
                _screens.Pop();
            }
        }

        //updates top screen
        public void Update(GameTime gameTime)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Update(gameTime);
                }
            }
            catch (Exception ex)
            {

            }
        }

        // draws top screen
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                if (_screens.Count > 0)
                {
                    _screens.Peek().Draw(spriteBatch);
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
            }
        }

        public void UnloadContent()
        {
            foreach (GameState state in _screens)
            {
                state.UnloadContent();
            }
        }

    }
}