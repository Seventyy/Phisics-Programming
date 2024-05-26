using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    internal class Vec2Test
    {
        public static void TestVec2()
        {
            // Test Vec2 constructor
            Vec2 vec1 = new Vec2(2, 3);
            Console.WriteLine("Vec2 constructor test: " + (vec1.x == 2 && vec1.y == 3));

            // Test SetXY function
            vec1.SetXY(4, 5);
            Console.WriteLine("SetXY test: " + (vec1.x == 4 && vec1.y == 5));

            // Test Length function
            float length = vec1.Length();
            Console.WriteLine("Length test: " + (length == Math.Sqrt(4 * 4 + 5 * 5)));

            // Test LengthSquared function
            float lengthSquared = vec1.LengthSquared();
            Console.WriteLine("LengthSquared test: " + (lengthSquared == 4 * 4 + 5 * 5));

            // Test Normalize function
            vec1.Normalize_____();
            Console.WriteLine("Normalize test: " + (vec1.Length() == 1));

            // Test Normalized function
            Vec2 normalizedVec = vec1.Normalized();
            Console.WriteLine("Normalized test: " + (normalizedVec.Length() == 1));

            // Test Dot function
            Vec2 vec2 = new Vec2(3, 4);
            float dotProduct = vec1.Dot(vec2);
            Console.WriteLine("Dot test: " + (dotProduct == 4 * 3 + 5 * 4));

            // Test Normal function
            Vec2 normalVec = vec1.Normal();
            Console.WriteLine("Normal test: " + (normalVec.x == vec1.x && normalVec.y == vec1.y));

            // Test operator +
            Vec2 vec3 = vec1 + vec2;
            Console.WriteLine("Operator + test: " + (vec3.x == vec1.x + vec2.x && vec3.y == vec1.y + vec2.y));

            // Test operator -
            Vec2 vec4 = vec1 - vec2;
            Console.WriteLine("Operator - test: " + (vec4.x == vec1.x - vec2.x && vec4.y == vec1.y - vec2.y));

            // Test operator *
            Vec2 vec5 = vec1 * 2;
            Console.WriteLine("Operator * test: " + (vec5.x == vec1.x * 2 && vec5.y == vec1.y * 2));

            // Test operator /
            Vec2 vec6 = vec1 / 2;
            Console.WriteLine("Operator / test: " + (vec6.x == vec1.x / 2 && vec6.y == vec1.y / 2));
        }
    }
}
