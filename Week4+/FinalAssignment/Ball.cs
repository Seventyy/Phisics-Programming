using System;
using GXPEngine;
using GXPEngine.Core;

public class Ball : EasyDraw
{
    private Vec2 _position;
    private Vec2 _velocity;
    private Vec2 _displacement;
    private float _rotation;
    private int _radius;

    private Sprite _texture; // Add a private field for the ball texture

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

    public Vec2 Displacement
    {
        get { return _displacement; }
    }

    public float Rotation
    {
        get { return _rotation; }
        set { _rotation = value; }
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
        _rotation = 0;

        SetOrigin(_radius, _radius);

        _texture = new Sprite("C:\\Users\\Seventy\\Documents\\CMGT\\Phisics Programming\\Week4+\\FinalAssignment\\ball.png"); 
        _texture.SetOrigin(_radius, _radius);
        AddChild(_texture);

        Draw(255, 255, 255);
    }

    private void Draw(byte red, byte green, byte blue)
    {
        Fill(red, green, blue);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }

    void FollowMouse()
    {
        _position.SetXY(Input.mouseX, Input.mouseY);
    }

    private void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    public void Step()
    {
        rotation = Vec2.Rad2Deg(_rotation);
        Draw(255, 255, 255);
        _displacement = _velocity * 1 / 60;
        Position += _displacement;
    }
}
