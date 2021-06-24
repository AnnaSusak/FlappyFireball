using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FlappyFire.Classes.UI
{
    class Rules
    {
        private string text;
        private Label label;
        private Vector2 position;
        private KeyboardState kState;
        public Rules()
        {
            text = "MegaPlay Flappy Fireball \r\nFrom Anna Susak, Eremina Victoria\r\nRules:\r\n" +
" Your task is to make the fireball fly as much as possible.\r\n The game has a record that is updated if you beat it\r\n" +
" In the game screen or the rules screen, you can return to the menu by pressing esc.\r\n A fireball is generated in the middle. \r\n" +
" If you hold down the space bar, the fireball will fall.\r\n" +
" It starts to fall, so that it jumps up, you need to press the space bar.\r\nAt the same time, it moves to the left.\r\n" +
" The game ends when the fireball is dropped. The task is to fly as much as possible.\r\n" +
 "There is a timer on top that shows how long the game lasts.\r\nYour record is displayed next to the timer.\r\n" +
 "Over time, the game becomes more complicated.\r\n Obstacles appear, when you collide with an obstacle, you lose. ";
            position = new Vector2(0, 0);
            label = new Label(text, position, Color.White);
        }
        public void LoadContent(ContentManager content)
        {
            label.LoadContent(content);
        }
        public void Draw(SpriteBatch s)
        {
            label.Draw(s);
        }
        public void Update()
        {
            kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Escape))
            {
                Game1.gameState = GameState.Menu;
            }
        }
    }
}
