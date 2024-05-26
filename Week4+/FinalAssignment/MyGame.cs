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
    List<BallCollider> colliders = new List<BallCollider>();

    public MyGame() : base(800, 600, false, false)
    {
        ball = new Ball(30, new Vec2(width / 2, height ));
        ball.Velocity = new Vec2(200, -100);
        AddChild(ball);

        colliders.Add(new BorderWall(new Vec2(width - 10, 10), new Vec2(width - 10, height - 10)));
        
    }

    void Update()
    {
        ball.Step();
        foreach (BallCollider collider in colliders)
        {
            if (collider.isColliding(ball))
            {
                collider.ResolveCollision(ball);
            }
        }
    }

}

