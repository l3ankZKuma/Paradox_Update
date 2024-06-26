using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;


namespace Paradox
{
    
    public class Potion : Items
    {
        
        private SoundEffect _potionSound;
        
        public Potion(Vector2 POS)
        {
            _position = POS;
            _sprite= Singleton.Instance.Content.Load<Texture2D>("Items/potion_b");
            _potionSound = Singleton.Instance.Content.Load<SoundEffect>("SoundEffect/Drink");
        }


        public override void Load()
        {
            _animation = new Animation(_sprite, 256/8, 29, 0.1f);
        }


        public override void Update(GameTime gameTime)
        {
            if (!_isCollected)
            {
                if (Singleton.Instance.PlayerCollisionBox.Intersects(new Rectangle((int)_position.X, (int)_position.Y, 32, 32)))
                {
                    _potionSound.Play();
                    Singleton.Instance.PlayerHP++;
                    _isCollected = true;
                }
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            if (!_isCollected)
            {
                _animation.Draw(true, _position, gameTime, 1.0f, Color.White);
            }
            
        }
        
        
    }
}