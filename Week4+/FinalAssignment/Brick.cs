using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    internal class Brick: EasyDraw, BallCollider
    {
        private Vec2 _position;
        private Vec2 _size;

        public Vec2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                UpdateScreenPosition();
            }
        }

        public Brick(Vec2 position, Vec2 size) : base((int)size.x, (int)size.y)
        {
            _position = position;
            _size = size;

            SetOrigin(0, 0);
            Draw(255, 0, 255);
            UpdateScreenPosition();
        }

        public bool isColliding(Ball ball)
        {
            if (ball == null) return false;

            Vec2 pos = ball.Position;
            float r = ball.Radius;
            float r_sq = ball.Radius * ball.Radius;

            float left = _position.x;
            float right = _position.x + _size.x;
            float top = _position.y;
            float bottom = _position.y + _size.y;

            Vec2 top_left = new Vec2(left, top);
            Vec2 top_right = new Vec2(right, top);
            Vec2 bottom_left = new Vec2(left, bottom);
            Vec2 bottom_right = new Vec2(right, bottom);

            if (pos.x < left - r ||
                pos.x > right + r ||
                pos.y < top - r ||
                pos.y > bottom + r)
            {
                return false;
            }

            if ((pos > top_left + new Vec2(-r, 0) && pos < bottom_right + new Vec2(r, 0)) ||
                (pos > top_left + new Vec2(0, -r) && pos < bottom_right + new Vec2(0, r)) ||
                (pos - top_left).LengthSquared() < r_sq ||
                (pos - top_right).LengthSquared() < r_sq ||
                (pos - bottom_left).LengthSquared() < r_sq ||
                (pos - bottom_right).LengthSquared() < r_sq)
            {
                return true;
            }
            
            return false;
        }

        public void ResolveCollision(Ball ball)
        {
            Vec2 last_pos = ball.Position - ball.Displacement;

            float left = _position.x;
            float right = _position.x + _size.x;
            float top = _position.y;
            float bottom = _position.y + _size.y;

            Vec2 top_left = new Vec2(left, top);
            Vec2 top_right = new Vec2(right, top);
            Vec2 bottom_left = new Vec2(left, bottom);
            Vec2 bottom_right = new Vec2(right, bottom);

            Vec2 normal = top_left;
            Vec2 corner = new Vec2(-1, 0); 


            if (last_pos.x <= left)
            {
                if (last_pos.y <= top)
                {
                    // Position is in the top-left space
                    corner = top_left;
                    normal = (last_pos - corner).Normalized();
                }
                else if (last_pos.y >= bottom)
                {
                    // Position is in the bottom-left space
                    corner = bottom_left;
                    normal = (last_pos - corner).Normalized();
                }
                else
                {
                    // Position is in the left space
                    corner = top_left;
                    normal = new Vec2(-1, 0);
                }
            }
            else if (last_pos.x >= right)
            {
                if (last_pos.y <= top)
                {
                    // Position is in the top-right space
                    corner = top_right;
                    normal = (last_pos - corner).Normalized();
                }
                else if (last_pos.y >= bottom)
                {
                    // Position is in the bottom-right space
                    corner = bottom_right;
                    normal = (last_pos - corner).Normalized();
                }
                else
                {
                    // Position is in the right space
                    corner = bottom_right;
                    normal = new Vec2(1, 0);
                }
            }
            else
            {
                if (last_pos.y <= top)
                {
                    // Position is in the top space
                    corner = top_left;
                    normal = new Vec2(0, -1);
                }
                else if (last_pos.y >= bottom)
                {
                    // Position is in the bottom space
                    corner = bottom_right;
                    normal = new Vec2(0, 1);
                }
                else
                {
                    Console.WriteLine("This shouldnt happen");
                }
            }

            float distance = (ball.Position - corner).Dot(normal);

            ball.Position -= ball.Displacement.Normalized() * (ball.Radius - distance) * ball.Displacement.Length() / -ball.Displacement.Dot(normal);
            ball.Velocity = ball.Velocity.Reflected(normal);

        }

        public void Break()
        {
            LateDestroy();
        }

        private void Draw(byte red, byte green, byte blue)
        {
            Stroke(red, green, blue);
            Rect(_size.x/2, _size.y/2, _size.x, _size.y);
        }
        void UpdateScreenPosition()
        {
            x = _position.x;
            y = _position.y;
        }
    }
}
