using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoGameTemplate
{
    public class Animator : Component
    {
        public int CurrentIndex { get; private set; }

        private float elapsed;

        private SpriteRenderer _spriteRenderer;
        private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
        private Animation currentAnimation;

        public override void Start()
        {
            _spriteRenderer = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += GameWorld.DeltaTime;

            CurrentIndex = (int)(elapsed * currentAnimation.FPS);

            if (currentAnimation.Sprites != null && CurrentIndex > currentAnimation.Sprites.Length - 1 ||
                currentAnimation.Rectangles != null && CurrentIndex > currentAnimation.Rectangles.Length - 1)
            {
                elapsed = 0;
                CurrentIndex = 0;
            }
            if (currentAnimation.Sprites != null)
            {
                _spriteRenderer.Sprite = currentAnimation.Sprites[CurrentIndex];
            }
            else
            {
                _spriteRenderer.Rectangle = currentAnimation.Rectangles[CurrentIndex];
                _spriteRenderer.Sprite = currentAnimation.Sprite;
            }
        }

        /// <summary>
        /// Adds animation to the _animations Dictionary used for animation
        /// </summary>
        /// <param name="animation"></param>
        public void AddAnimation(Animation animation)
        {
            _animations.Add(animation.Name, animation);

            if (currentAnimation == null)
            {
                currentAnimation = animation;
            }
        }

        /// <summary>
        /// Plays the animation via the currentIndex
        /// </summary>
        /// <param name="animationName"></param>
        public void PlayAnimation(string animationName)
        {
            if (animationName != currentAnimation.Name)
            {
                currentAnimation = _animations[animationName];
                elapsed = 0;
                CurrentIndex = 0;
            }
        }
    }
}
