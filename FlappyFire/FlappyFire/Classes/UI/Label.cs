using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace FlappyFire.Classes.UI
{
    class Label
    {
        private Vector2 position;
        private string text;
        private SpriteFont spriteFontMenu;
        private SpriteFont spriteFontRules;
        private Color color;
        public Color Color { set { color = value; } }
        public Color ChosenColor { get { return begintColor; } }
        private Color begintColor;
        private bool isVisible;
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        public Label(string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;
            begintColor = color;
            isVisible = true;
        }
        public void ResetColor()
        {
            color = begintColor;
        }
        public void LoadContent(ContentManager content)
        {
            spriteFontMenu = content.Load<SpriteFont>("File");
            spriteFontRules = content.Load<SpriteFont>("FontRules");
        }
        public void Draw(SpriteBatch s)
        {
            switch (Game1.gameState)
            {
                case GameState.Menu:
                    s.DrawString(spriteFontMenu, text, position, color);
                    break;
                case GameState.Rules:
                    s.DrawString(spriteFontRules, text, position, color);
                    break;
                default:
                    break;
            }
            
        }
    }
}
