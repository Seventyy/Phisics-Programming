using System;
using GXPEngine;
using GXPEngine.Core;	// For Mathf

public struct Vec2
{
    public float x;
    public float y;

    public Vec2(float _x = 0, float _y = 0)
    {
        x = _x;
        y = _y;
    }

    public override string ToString()
    {
        return String.Format("({0},{1})", x, y);
    }

    public void SetXY(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    public float Length()
    {
        return Mathf.Sqrt(x * x + y * y);
    }
    public float LengthSquared()
    {
        return x * x + y * y;
    }

    public void Normalize()
    {
        float len = Length();
        if (len == 0) return;
        x /= len;
        y /= len;
    }

    public Vec2 Normalized()
    {
        float len = Length();
        if (len == 0) return new Vec2(0, 0);
        return new Vec2(x, y) / len;
    }

    public float Dot(Vec2 other)
    {
        return x * other.x + y * other.y;
    }

    public Vec2 Normal()
    {
        return new Vec2(-y, x).Normalized();
    }

    public static Vec2 operator +(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x + right.x, left.y + right.y);
    }

    public static Vec2 operator -(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x - right.x, left.y - right.y);
    }

    public static Vec2 operator *(Vec2 v, float scalar)
    {
        return new Vec2(v.x * scalar, v.y * scalar);
    }

    public static Vec2 operator *(float scalar, Vec2 v)
    {
        return new Vec2(v.x * scalar, v.y * scalar);
    }

    public static Vec2 operator /(Vec2 v, float scalar)
    {
        return new Vec2(v.x / scalar, v.y / scalar);
    }

    public static float Deg2Rad(float degrees)
    {
        return degrees * (float)Math.PI / 180f;
    }

    public static float Rad2Deg(float radians)
    {
        return radians * 180f / (float)Math.PI;
    }

    public static Vec2 GetUnitVectorDeg(float degrees)
    {
        return GetUnitVectorRad(Deg2Rad(degrees));
    }

    public static Vec2 GetUnitVectorRad(float radians)
    {
        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);
        return new Vec2(x, y);
    }

    public static Vec2 RandomUnitVector()
    {
        return GetUnitVectorRad((float)(new Random().NextDouble() * 2 * Math.PI));
    }

    public void SetAngleDegrees(float degrees)
    {
        SetAngleRadians(Deg2Rad(degrees));
    }

    public void SetAngleRadians(float radians)
    {
        float length = Length();
        x = Mathf.Cos(radians) * length;
        y = Mathf.Sin(radians) * length;
    }

    public float GetAngleRadians()
    {
        return Mathf.Atan2(y, x);
    }

    public float GetAngleDegrees()
    {
        return Rad2Deg(GetAngleRadians());
    }

    public void RotateDegrees(float degrees)
    {
        RotateRadians(Deg2Rad(degrees));
    }

    public void RotateRadians(float radians)
    {        
        float sin = (float)Math.Sin(radians);
        float cos = (float)Math.Cos(radians);

        this = new Vec2(x * cos - y * sin, x * sin + y * cos);
    }

    public void RotateAroundDegrees(Vec2 point, float degrees)
    {
        RotateAroundRadians(point, Deg2Rad(degrees));
    }

    public void RotateAroundRadians(Vec2 point, float radians)
    {
        this = this.Rotated(radians) + point;
    }

    public Vec2 Rotated(float rad) 
    {
        Vec2 vec = new Vec2(x,y);
        vec.RotateRadians(rad);
        return vec;
    }
}

