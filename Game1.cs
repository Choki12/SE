using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace NourishMeant
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteBatch _spriteBatch2;

        Texture2D mySprite; //will figure out what to use this for
        Texture2D background;
        //Texture2D background2;
        
       
        //fading out logo screen
        int mAlphaValue = 1;
        int mFadeIncrement = 3;
        double ScreenDelay = 10;
        double mFadeDelay = .035;

        int counter = 0;

        /*Game states for managing game behavior */
        enum GameStates { Menu, 
            Playing, 
            Pause, 
            Intro } 

        public Game1()
        {

            /*Obtained from https://www.youtube.com/watch?v=-XEmsZNKonM
              The Xamarin Show - Write Once play everywhere with Dean Ellis*/

            _graphics = new GraphicsDeviceManager(this);
            /*{
                PreferredBackBufferHeight = 1080,
                PreferredBackBufferWidth = 2400,
                IsFullScreen = true,
            };*/

            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            TouchPanel.EnabledGestures = GestureType.None;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Load content from the content pipeline
            mySprite = Content.Load<Texture2D>("CharactersBright_Line1");
            background = Content.Load<Texture2D>("drawable-port-xxhdpi-screen");
            

            GameStateManager.Instance.SetContent(Content);
            GameStateManager.Instance.AddNewScreen(new Play(GraphicsDevice));
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds - 2;

            mAlphaValue += mFadeIncrement;

            if (mFadeDelay <= 0)
            {
                counter += 1;
                mFadeDelay = .035;
                mAlphaValue += mFadeIncrement;
                
                if (mAlphaValue >= 255 || mAlphaValue <= 0)
                {
                    mFadeIncrement *= -1;
                    counter += 1;
                    
                }
     
            }
            GameStateManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            //we alert
            _spriteBatch.Begin();

            //spriteBatch draw
            _spriteBatch.Draw(background, new Vector2(0, 0), new Color (255, 255, 255, MathHelper.Clamp(mAlphaValue, 0, 255)));
            //_spriteBatch.Draw(mySprite, new Vector2(150, 150), Color.White);
            
            _spriteBatch.End();



            //GameStateManager.Instance.Draw(_spriteBatch);
            
            /*Written By Boitshoko Tumane*/
            ScreenDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            if(ScreenDelay <= 0)
            {
                FadeToBlack(_spriteBatch, background, 1);
                GameStateManager.Instance.Draw(_spriteBatch);
            }




            base.Draw(gameTime);
            
        }

        protected override void UnloadContent ()
        {
            GameStateManager.Instance.UnloadContent();
        }

        /*Written by Boitshoko Tumane*/
        public void FadeToBlack(SpriteBatch spriteBatch, Texture2D texture ,float alpha)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(texture,
                             new Vector2(0, 0),
                             Color.Black * alpha);

            spriteBatch.End();
        }
    }
}
