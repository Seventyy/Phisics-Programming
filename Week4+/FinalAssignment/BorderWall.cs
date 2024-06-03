using System;
using GXPEngine;

public class BorderWall : EasyDraw, BallCollider
{
    private Vec2 _start;
    private Vec2 _end;
    private Vec2 _normal;

    public Vec2 Normal
    {
        get { return _normal; }
    }

    public BorderWall(Vec2 start, Vec2 end, bool reverse_normal = false) : base(800, 600)
    {
        _start = start;
        _end = end;

        _normal = (reverse_normal ? -1 : 1) * (_end - _start).Normal();

        x = 0;
        y = 0;

        SetOrigin(0, 0);
        Draw(255, 0, 255);
    }

    private void Draw(byte red, byte green, byte blue)
    {
        Stroke(red, green, blue);
        Line(_start.x, _start.y, _end.x, _end.y);
    }

    public bool isColliding(Ball ball)
    {
        if (ball == null) return false;
        if ((ball.Position - _start).Dot(_normal) < ball.Radius)
        {
            return true;
        }
        return false;
    }

    public void ResolveCollision(Ball ball)
    {
        float distance = (ball.Position - _start).Dot(_normal);

        ball.Position -= ball.Displacement.Normalized() * (ball.Radius - distance) * ball.Displacement.Length() / -ball.Displacement.Dot(_normal);
        ball.Velocity = ball.Velocity.Reflected(_normal);

    }
}
