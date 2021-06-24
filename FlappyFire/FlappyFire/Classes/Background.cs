using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace FlappyFire.Classes
{
    class Background
    {
        private Texture2D textureGame;
        private Vector2 position;
        private Texture2D textureMenuRules;
        public Background()
        {
            textureGame = null;
            textureMenuRules = null;
            position = new Vector2(0, 0);
        }
        public void LoadContent(ContentManager m)
        {
            textureMenuRules = m.Load<Texture2D>("menuBg");
            textureGame=m.Load<Texture2D>("GameBg");
        }
        public void Draw(SpriteBatch s)
        {
            switch (Game1.gameState)
            {
                case GameState.Menu:
                    s.Draw(textureMenuRules, position, Color.White);
                    break;
                case GameState.Play:
                    s.Draw(textureGame, position, Color.White);
                    break;
                case GameState.Rules:
                    s.Draw(textureMenuRules, position, Color.White);
                    break;
                default:
                    break;
            }
            
        }
        public void Update()
        {

        }
    }
}
