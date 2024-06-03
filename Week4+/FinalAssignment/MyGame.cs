using System;
using GXPEngine;
using System.Drawing;
using System.Collections.Generic;
using GXPEngine.Core;

public class MyGame : Game
{	
	static void Main() {
		new MyGame().Start();
	}

    Ball ball;
    List<BorderWall> borderWalls = new List<BorderWall>();
    List<Brick> bricks = new List<Brick>();
    Paddle paddle;

    Vec2 clickPos;

    public MyGame() : base(800, 600, false, false)
    {
        borderWalls.Add(new BorderWall(new Vec2(width - 50, 10), new Vec2(width - 10, height - 10)));
        borderWalls.Add(new BorderWall(new Vec2(50, 10), new Vec2(10, height - 10), true));
        borderWalls.Add(new BorderWall(new Vec2(50, 10), new Vec2(width - 50, 10)));

        Vec2 offset = new Vec2(110, 100);
        Vec2 size = new Vec2(40, 20);
        Vec2 separation = new Vec2(20, 20);

        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                bricks.Add(new Brick(offset + 
                    new Vec2((size.x + separation.x) * i, (size.y + separation.y) * j),
                    size));
            }
        }

        paddle = new Paddle(new Vec2(350, 550), new Vec2(100, 25));
        AddChild(paddle);

        foreach (Brick brick in bricks)
        {
            AddChild(brick);
        }
        foreach (BorderWall borderWall in borderWalls)
        {
            AddChild(borderWall);
        }

        new Vec2(0,0).TestAllMethods();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPos = new Vec2(Input.mouseX, Input.mouseY);
            ball?.Destroy();
            ball = new Ball(25, clickPos);
            AddChild(ball);
        }
        if (Input.GetMouseButtonUp(0))
        {
            ball.Velocity = (new Vec2(Input.mouseX, Input.mouseY) - clickPos) * 2;
        }
        if (Input.GetMouseButton(0))
        {
            if (ball != null)
            {
                ball.Rotation = (new Vec2(Input.mouseX, Input.mouseY) - clickPos).GetAngleRadians();
                ball.Velocity = Vec2.GetUnitVectorDeg(rotation) * 2;
            }
        }
        if (Input.GetKey(Key.A))
        {
            paddle.Velocity = new Vec2(-500, 0);
        }
        if (Input.GetKey(Key.D))
        {
            paddle.Velocity = new Vec2(500, 0);
        }

        ball?.Step();
        paddle?.Step();

        foreach (BorderWall borderWall in borderWalls)
        {
            if (borderWall.isColliding(ball))
            {
                borderWall?.ResolveCollision(ball);
            }
        }

        List<Brick> bricksToRemove = new List<Brick>();
        foreach (Brick brick in bricks)
        {
            if (brick.isColliding(ball))
            {
                brick?.ResolveCollision(ball);
                bricksToRemove.Add(brick);
            }
        }

        foreach (Brick brick in bricksToRemove)
        {
            brick.Break();
            bricks.Remove(brick);
        }

        if (paddle.isColliding(ball))
        {
            paddle.ResolveCollision(ball);
        }
        
    }

}

