using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;

public class MyGame : Game
{	
	static void Main() {
		new MyGame().Start();
	}

    Ball ball;
    List<Collider> colliders = new List<Collider>();

    public MyGame() : base(800, 600, false, false)
    {
        ball = new Ball(30, new Vec2(width / 2, height / 2));
        ball.Velocity = new Vec2(100, -100);
        AddChild(ball);

        colliders.Add(new BorderWall(new Vec2(width - 10, 0 - 10), new Vec2(width - 10, height - 10)));
        
    }

    void Update()
    {
        ball.Step();
        foreach (Collider collider in colliders)
        {
            if (collider.isColliding(ball))
            {
                collider.ResolveCollision(ball);
            }
        }
    }

}

