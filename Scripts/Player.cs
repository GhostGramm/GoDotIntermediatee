using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 velocity = new Vector2(0, 0);
    private int moveSpeed = 100;
    private int jumpHeight = 1000;
    private int gravity = 30;
    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if (Input.IsActionPressed("ui_left"))
        {
            velocity.x = -moveSpeed;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x = moveSpeed;
        }
        if (IsOnFloor())
        {
            if (Input.IsActionJustPressed("jump"))
            {
                velocity.y = -jumpHeight;
            }
        }

        velocity.y += gravity;

        velocity = MoveAndSlide(velocity, Vector2.Up);

        velocity.x = Mathf.Lerp(velocity.x, 0, 0.1f);     // interpolates between 2 points to stop the player gradually;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
