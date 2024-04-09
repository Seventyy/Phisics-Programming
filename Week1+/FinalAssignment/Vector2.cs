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

    // TODO: Implement Length, Normalize, Normalized, SetXY methods 

    public float Length()
    {
        return Mathf.Sqrt(x * x + y * y);
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

    public void SetXY(float pX, float pY)
    {
        x = pX;
        y = pY;
    }

    // TODO: Implement subtract, scale operators

    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.x + right.x, left.y + right.y);
    }

    public override string ToString()
    {
        return String.Format("({0},{1})", x, y);
    }
}

