using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    internal interface BallCollider
    {
        bool isColliding(Ball ball);
        void ResolveCollision(Ball ball);
    }
}
