using Microsoft.Xna.Framework;

namespace MonoGameTemplate
{
    public class Player : Component
    {
        private float speed = 200;
        private Animator animator;

        public void Move(Vector2 _velocity)
        {
            if (_velocity != Vector2.Zero)
            {
                _velocity.Normalize();
            }

            _velocity *= speed;

            GameObject.Transform.Translate(_velocity * GameWorld.DeltaTime);
        }


        public override void Start()
        {
            SpriteRenderer sr = GameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
            // sr.SetSprite("Insert sprite path here");
            sr.SetSprite("MinerTest");
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth / 2, GameWorld.Instance.Graphics.PreferredBackBufferHeight - sr.Sprite.Height / 2);
            animator = (Animator)GameObject.GetComponent<Animator>();
        }

        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);
        }
    }
}
