using System;
using GXPEngine; // Allows using Mathf functions

public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float pX = 0, float pY = 0)
    {
        x = pX;
        y = pY;
    }

    public float Length()
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public float LengthSquared()
    {
        return x * x + y * y;
    }

    public Vector2 Normalized()
    {
        float length = Length();
        if (length == 0)
        {
            return new Vector2(0, 0);
        }
        return new Vector2(x / length, y / length);
    }

    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x + right.x, left.y + right.y);
    }

    public static Vector2 operator -(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x - right.x, left.y - right.y);
    }

    public static Vector2 operator *(Vector2 left, float right)
    {
        return new Vector2(left.x * right, left.y * right);
    }

    public static Vector2 operator /(Vector2 left, float right)
    {
        return new Vector2(left.x / right, left.y / right);
    }

    public override string ToString()
    {
        return String.Format("({0},{1})", x, y);
    }
}

