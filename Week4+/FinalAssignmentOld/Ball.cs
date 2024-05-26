using System;
using GXPEngine;

public class Ball : EasyDraw
{
    private Vec2 _position;
    private Vec2 _velocity;

    private int _radius;

    public Vec2 Position
    {
        get { return _position; }
        set
        {
            _position = value;
            UpdateScreenPosition();
        }
    }

    public Vec2 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    public int Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }

    public Ball(int radius, Vec2 position) : base(radius * 2 + 1, radius * 2 + 1)
    {
        _radius = radius;
        Position = position;

        SetOrigin(_radius, _radius);

        Draw(255, 255, 255);
    }

    private void Draw(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }

    private void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    public void Step()
    {
        Position += _velocity * 1 / 60;
    }
}
