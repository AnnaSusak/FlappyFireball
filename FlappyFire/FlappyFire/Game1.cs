using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media; 
using System;
using System.Collections.Generic;
using System.Text;
using FlappyFire.Classes;
using FlappyFire.Classes.UI;
namespace FlappyFire
{
    public enum GameState { Menu, Play, Exit, Rules };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static GameState gameState { get; set; }
        private Background background = new Background();
        private Menu menu=new Menu();
        private Song song;
        private Player player = new Player();
        private Rules rules = new Rules();
        private KeyboardState kState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameState = GameState.Menu;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            song = Content.Load<Song>("musik");
            // начинаем проигрывание мелодии
            MediaPlayer.Volume = 50;
            MediaPlayer.Play(song);
            // повторять после завершения
            MediaPlayer.IsRepeating = true;
            // прикрепляем обработчик изменения состояния проигрывания мелодии
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            player.LoadContent(Content);
            background.LoadContent(Content);
            menu.LoadContent(Content);
            rules.LoadContent(Content);       
        }
        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.Menu:
                    menu.Update();
                    break;
                case GameState.Play:
                    player.Update(gameTime);
                    kState = Keyboard.GetState();
                    if (kState.IsKeyDown(Keys.Escape))
                    {
                        Game1.gameState = GameState.Menu;
                    }
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.Rules:
                    rules.Update();
                    break;
                default:
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            background.Draw(_spriteBatch);
            switch (gameState)
            {
                case GameState.Menu:
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Play:
                    player.Draw(_spriteBatch);
                    break;
                case GameState.Rules:
                    rules.Draw(_spriteBatch);
                    break;
                default:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
