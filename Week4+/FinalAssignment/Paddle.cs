using System;
using TiledMapParser;

namespace GXPEngine
{
    internal class Paddle:Brick
    {
        private Vec2 _velocity;

        public Vec2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Paddle(Vec2 position, Vec2 size) : base(position, size)
        {
        }

        public void Step()
        {
            Position = new Vec2(Math.Max(50, Math.Min(650, Position.x + _velocity.x * 1 / 60)), Position.y);
            _velocity *= 0.9f;
        }

    }
}
