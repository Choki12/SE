using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NourishMeant
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D mySprite; //will figure out what to use this for
        Texture2D background;
        SpriteFont font;

        //fading out logo screen
        int mAlphaValue = 1;
        int mFadeIncrement = 3;
        double mFadeDelay = .035;

        public Game1()
        {

            /*https://www.youtube.com/watch?v=-XEmsZNKonM
            * The Xamarin Show - Write Once play everywhere with Dean Ellis*/

            _graphics = new GraphicsDeviceManager(this);
            /*{
                PreferredBackBufferHeight = 1080,
                PreferredBackBufferWidth = 2400,
                IsFullScreen = true,
            };*/

            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            
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
            //font = Content.Load<SpriteFont>("Font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

            mAlphaValue += mFadeIncrement;

            if (mAlphaValue >= 255 || mAlphaValue <= 0)
            {
                mFadeIncrement *= -1;
            }

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

            base.Draw(gameTime);
        }
    }
}
