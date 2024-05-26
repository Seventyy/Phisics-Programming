using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    internal interface Collider
    {
        bool isColliding(Ball ball);
        void ResolveCollision(Ball ball);
    }
}
