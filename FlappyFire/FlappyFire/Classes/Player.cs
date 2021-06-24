using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;

namespace FlappyFire.Classes
{
	class Player
	{
		Random random = new Random();

		private Texture2D texture1;
		private Texture2D texture2;
		private Texture2D texture3;
		private Vector2 position;
		private int speed;
		public int randomGeneric;
		private KeyboardState keyboard; // нынешнее состояние клавиатуры
		private KeyboardState prevKeyboard; // прошлое состояние клавиатуры

		private Rectangle collisionBox;

		public TimeSpan elapsed;
		public Vector2 timerPosition;
		public SpriteFont timer;

		public Rectangle CollisionBox
		{
			get { return collisionBox; }
		}

		public Player()
		{
			texture1 = null;
			texture2 = null;
			texture3 = null;
			position = new Vector2(350, 200);
			speed = 20;
			randomGeneric = random.Next(0, 3);
			timerPosition = new Vector2(10, 10);
		}
		public void LoadContent(ContentManager content)
		{
			texture1 = content.Load<Texture2D>("BlueBall");
			texture2 = content.Load<Texture2D>("RedBall");
			texture3 = content.Load<Texture2D>("GreenBall");
			timer = content.Load<SpriteFont>("FontRules");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (randomGeneric == 0)
			{
				spriteBatch.Draw(texture1, position, Color.White);
			}
			if (randomGeneric == 1)
			{
				spriteBatch.Draw(texture2, position, Color.White);
			}
			if (randomGeneric == 2)
			{
				spriteBatch.Draw(texture3, position, Color.White);
			}
			string textTimer = Convert.ToString(elapsed.Seconds);
			spriteBatch.DrawString(timer, textTimer, timerPosition, Color.White);
		}
		public void Update(GameTime gameTime)
		{
			elapsed += gameTime.ElapsedGameTime;
			keyboard = Keyboard.GetState();
			// проверка
			if (keyboard.IsKeyDown(Keys.Space) && (keyboard != prevKeyboard))
			{
				position.Y -= speed;
			}
			else
			{
				position.Y += 1;
			}
			prevKeyboard = keyboard;

			// Установка коллизии
			if (randomGeneric == 0)
			{
				collisionBox = new Rectangle((int)position.X, (int)position.Y,
				texture1.Width, texture1.Height);
			}
			if (randomGeneric == 1)
			{
				collisionBox = new Rectangle((int)position.X, (int)position.Y,
				texture2.Width, texture2.Height);
			}
			if (randomGeneric == 2)
			{
				collisionBox = new Rectangle((int)position.X, (int)position.Y,
				texture3.Width, texture3.Height);
			}
			if (randomGeneric == 2)
			{
				collisionBox = new Rectangle((int)position.X, (int)position.Y, texture3.Width, texture3.Height);
			}

		}
	}
}