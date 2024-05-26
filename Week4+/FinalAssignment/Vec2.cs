using System;
using GXPEngine;

public struct Vec2 
{
	public float x;
	public float y;

	public Vec2 (float pX = 0, float pY = 0) 
	{
		x = pX;
		y = pY;
	}

	public override string ToString () 
	{
		return String.Format ("({0},{1})", x, y);
	}

	public void SetXY(float _x, float _y) 
	{
		x = _x;
		y = _y;
	}

	public float Length() {
		return Mathf.Sqrt (x * x + y * y);
	}

	public void Normalize() {
		float len = Length ();
		if (len == 0) return;

		x /= len;
		y /= len;
	}

	public Vec2 Normalized() {
		float len = Length ();
        if (len == 0) return new Vec2(0,0);

        return new Vec2 (x / len, y / len);
    }

	public static Vec2 operator +(Vec2 left, Vec2 right) {
		return new Vec2 (left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right) {
		return new Vec2 (left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(Vec2 v, float scalar) {
		return new Vec2 (v.x * scalar, v.y * scalar);
	}

	public static Vec2 operator *(float scalar, Vec2 v) {
		return new Vec2 (v.x * scalar, v.y * scalar);
	}

	public static Vec2 operator /(Vec2 v, float scalar) {
		return new Vec2 (v.x / scalar, v.y / scalar);
	}

    //////////////////////////////////////////////////////////////////////
    
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
        Vec2 vec = new Vec2(x, y);
        vec.RotateRadians(rad);
        return vec;
    }

    //////////////////////////////////////////////////////////////////////


    public float Dot(Vec2 other)
    {
        return x * other.x + y * other.y;
    }

    public Vec2 Normal()
    {
        return new Vec2(-y, x).Normalized();
    }

    public Vec2 Reflected(Vec2 normal)
    {
        normal.Normalize();
        return this - 2 * this.Dot(normal) * normal;
    }

    public Vec2 Projected(Vec2 other)
    {
        other.Normalize();
        return other * (x * other.x + y * other.y);
    }

    // test all the methods in this class
    public bool TestAllMethods()
    {
        bool allTestsPassed = true;

        // Test SetXY
        Vec2 testVec1 = new Vec2();
        testVec1.SetXY(3, 4);
        if (testVec1.x != 3 || testVec1.y != 4)
        {
            allTestsPassed = false;
            Console.WriteLine("SetXY test failed");
        }

        // Test Length
        Vec2 testVec2 = new Vec2(-3, 4);
        float length = testVec2.Length();
        if (length != 5)
        {
            allTestsPassed = false;
            Console.WriteLine("Length test failed");
        }

        // Test Normalize
        Vec2 testVec3 = new Vec2(3, 4);
        testVec3.Normalize();
        if (testVec3.Length() != 1 || testVec3.x != 0.6 || testVec3.y != 0.8 )
        {
            allTestsPassed = false;
            Console.WriteLine("Normalize test failed");
        }

        // Test Normalized
        Vec2 testVec4 = new Vec2(3, 4);
        Vec2 normalizedVec = testVec4.Normalized();
        if (normalizedVec.Length() != 1 && normalizedVec.x == 0.6 && normalizedVec.y == 0.8)
        {
            allTestsPassed = false;
            Console.WriteLine("Normalized test failed");
        }

        // Test operator +
        Vec2 testVec5 = new Vec2(3, 4);
        Vec2 testVec6 = new Vec2(1, 2);
        Vec2 sumVec = testVec5 + testVec6;
        if (sumVec.x != 4 || sumVec.y != 6)
        {
            allTestsPassed = false;
            Console.WriteLine("Operator + test failed");
        }

        // Test operator -
        Vec2 testVec7 = new Vec2(3, 4);
        Vec2 testVec8 = new Vec2(1, 2);
        Vec2 diffVec = testVec7 - testVec8;
        if (diffVec.x != 2 || diffVec.y != 2)
        {
            allTestsPassed = false;
            Console.WriteLine("Operator - test failed");
        }

        // Test operator *
        Vec2 testVec9 = new Vec2(3, 4);
        float scalar = 2;
        Vec2 mulVec = testVec9 * scalar;
        if (mulVec.x != 6 || mulVec.y != 8)
        {
            allTestsPassed = false;
            Console.WriteLine("Operator * test failed");
        }

        // Test operator /
        Vec2 testVec10 = new Vec2(6, 8);
        float divisor = 2;
        Vec2 divVec = testVec10 / divisor;
        if (divVec.x != 3 || divVec.y != 4)
        {
            allTestsPassed = false;
            Console.WriteLine("Operator / test failed");
        }

        // Test Deg2Rad
        float degrees = 90;
        float radians = Vec2.Deg2Rad(degrees);
        if (radians != (float)Math.PI / 2)
        {
            allTestsPassed = false;
            Console.WriteLine("Deg2Rad test failed");
        }

        // Test Rad2Deg
        float testRadians = (float)Math.PI / 2;
        float testDegrees = Vec2.Rad2Deg(testRadians);
        if (testDegrees != 90)
        {
            allTestsPassed = false;
            Console.WriteLine("Rad2Deg test failed");
        }

        // Test GetUnitVectorDeg
        float testDegrees2 = 45;
        Vec2 unitVecDeg = Vec2.GetUnitVectorDeg(testDegrees2);
        if (unitVecDeg.x != (float)Math.Sqrt(2) / 2 || unitVecDeg.y != (float)Math.Sqrt(2) / 2)
        {
            allTestsPassed = false;
            Console.WriteLine("GetUnitVectorDeg test failed");
        }

        // Test GetUnitVectorRad
        float testRadians2 = (float)Math.PI / 4;
        Vec2 unitVecRad = Vec2.GetUnitVectorRad(testRadians2);
        if (unitVecRad.x != (float)Math.Sqrt(2) / 2 || unitVecRad.y != (float)Math.Sqrt(2) / 2)
        {
            allTestsPassed = false;
            Console.WriteLine("GetUnitVectorRad test failed");
        }

        // Test RandomUnitVector
        Vec2 randomUnitVec = Vec2.RandomUnitVector();
        if (randomUnitVec.Length() != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("RandomUnitVector test failed");
        }

        // Test SetAngleDegrees
        Vec2 testVec11 = new Vec2(3, 4);
        testVec11.SetAngleDegrees(45);
        if (testVec11.x != (float)Math.Sqrt(2) / 2 * 5 || testVec11.y != (float)Math.Sqrt(2) / 2 * 5)
        {
            allTestsPassed = false;
            Console.WriteLine("SetAngleDegrees test failed");
        }

        // Test SetAngleRadians
        Vec2 testVec12 = new Vec2(3, 4);
        testVec12.SetAngleRadians((float)Math.PI / 4);
        if (testVec12.x != (float)Math.Sqrt(2) / 2 * 5 || testVec12.y != (float)Math.Sqrt(2) / 2 * 5)
        {
            allTestsPassed = false;
            Console.WriteLine("SetAngleRadians test failed");
        }

        // Test GetAngleRadians
        Vec2 testVec13 = new Vec2(1, 1);
        float angleRadians = testVec13.GetAngleRadians();
        if (angleRadians != (float)Math.PI / 4)
        {
            allTestsPassed = false;
            Console.WriteLine("GetAngleRadians test failed");
        }

        // Test GetAngleDegrees
        Vec2 testVec14 = new Vec2(1, 1);
        float angleDegrees = testVec14.GetAngleDegrees();
        if (angleDegrees != 45)
        {
            allTestsPassed = false;
            Console.WriteLine("GetAngleDegrees test failed");
        }

        // Test RotateDegrees
        Vec2 testVec15 = new Vec2(1, 0);
        testVec15.RotateDegrees(90);
        if (testVec15.x != 0 || testVec15.y != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("RotateDegrees test failed");
        }

        // Test RotateRadians
        Vec2 testVec16 = new Vec2(1, 0);
        testVec16.RotateRadians((float)Math.PI / 2);
        if (testVec16.x != 0 || testVec16.y != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("RotateRadians test failed");
        }

        // Test RotateAroundDegrees
        Vec2 testVec17 = new Vec2(1, 0);
        Vec2 point = new Vec2(1, 0);
        testVec17.RotateAroundDegrees(point, 90);
        if (testVec17.x != 1 || testVec17.y != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("RotateAroundDegrees test failed");
        }

        // Test RotateAroundRadians
        Vec2 testVec18 = new Vec2(1, 0);
        Vec2 point2 = new Vec2(1, 0);
        testVec18.RotateAroundRadians(point2, (float)Math.PI / 2);
        if (testVec18.x != 1 || testVec18.y != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("RotateAroundRadians test failed");
        }

        // Test Rotated
        Vec2 testVec19 = new Vec2(1, 0);
        Vec2 rotatedVec = testVec19.Rotated((float)Math.PI / 2);
        if (rotatedVec.x != 0 || rotatedVec.y != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("Rotated test failed");
        }

        // Test Dot
        Vec2 testVec20 = new Vec2(1, 2);
        Vec2 testVec21 = new Vec2(3, 4);
        float dotProduct = testVec20.Dot(testVec21);
        if (dotProduct != 11)
        {
            allTestsPassed = false;
            Console.WriteLine("Dot test failed");
        }

        // Test Normal
        Vec2 testVec22 = new Vec2(1, 2);
        Vec2 normalVec = testVec22.Normal();
        if (normalVec.x != -2 || normalVec.y != 1)
        {
            allTestsPassed = false;
            Console.WriteLine("Normal test failed");
        }

        // Test Reflect
        Vec2 testVec23 = new Vec2(1, 1);
        Vec2 normalVec2 = new Vec2(0, 1);
        Vec2 reflectedVec = testVec23.Reflected(normalVec2);
        if (reflectedVec.x != 1 || reflectedVec.y != -1)
        {
            allTestsPassed = false;
            Console.WriteLine("Reflect test failed");
        }

        return allTestsPassed;
    }
}

