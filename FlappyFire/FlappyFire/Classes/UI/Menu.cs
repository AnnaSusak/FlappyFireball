using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace FlappyFire.Classes.UI
{
    class Menu
    {
        private string[] texts = { "Play", "Rules", "Exit"};
        private int selected=0;
        private List<Label> items;
        private KeyboardState kState;
        private KeyboardState prevState;
        private Vector2 position=new Vector2(400, 300);
        public Menu()
        {
            items = new List<Label>();
            for (int i = 0; i <texts.Length; i++)
            {
                items.Add(new Label(texts[i], position, Color.Yellow));
                position.Y += 60;
            }
        }
        public void LoadContent(ContentManager m)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].LoadContent(m);
            }
        }
        public void Draw(SpriteBatch s)
        {
            items[selected].Color = Color.Red;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Draw(s);
            }
        }
        public void Update()
        {
            kState = Keyboard.GetState();
            // проверка
            if (kState.IsKeyDown(Keys.D) && (kState != prevState))
            {
                if (selected < items.Count - 1)
                {
                    items[selected].ResetColor();
                    selected++;
                }

            }
            // Up
            if (kState.IsKeyDown(Keys.U) && (kState != prevState))
            {
                if (selected > 0)
                {
                    items[selected].ResetColor();
                    selected--;
                }

            }
            //Enter
            if (kState.IsKeyDown(Keys.Enter))
            {

                switch (selected)
                {
                    case 0: //Play
                        Game1.gameState = GameState.Play;
                        break;
                    case 1: //Rules
                        Game1.gameState = GameState.Rules;
                        break;
                    case 2: //Exit
                        Game1.gameState = GameState.Exit;
                        break;
                    default:
                        break;
                }
            }
            prevState = kState;
        }
    }
}
