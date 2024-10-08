﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    internal class BorderWall : EasyDraw, Collider
    {
        private Vec2 _start;
        private Vec2 _end;
        private Vec2 _normal;

        public Vec2 Normal
        {
            get { return _normal; }
        }

        public BorderWall(Vec2 start, Vec2 end) : base(800, 600)
        {
            _start = start;
            _end = end;

            _normal = (_end - _start).Normal();

            SetOrigin(0, 0);

            Draw(255, 255, 255);
        }

        private void Draw(byte red, byte green, byte blue)
        {
            Stroke(red, green, blue);
            Line(_start.x, _start.y, _end.x, _end.y);
        }

        public bool isColliding(Ball ball)
        {
            if ((ball.Position - _start).Dot(_normal) < ball.Radius)
            {
                return true;
            }
            return false;
        }

        public void ResolveCollision(Ball ball)
        {
            float distance = (ball.Position - _start).Dot(_normal);
            
            ball.Position += _normal * (ball.Radius - distance);
            ball.Velocity = ball.Velocity.Reflected(_normal);
        }
    }
}
