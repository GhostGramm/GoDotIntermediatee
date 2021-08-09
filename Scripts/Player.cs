using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 velocity = new Vector2(0, 0);
    private int moveSpeed = 200;
    private int jumpHeight = 1000;
    private int gravity = 30;
    private bool isJumping = false;
    private float jumpTime = 1f;
    private float jumpTimeReset = 1f;
    private AnimatedSprite animatedSprite;
    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("animatedSprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        PlayerMovement(delta);
    }

    public void PlayerMovement(float delta)
    {
        if (Input.IsActionPressed("ui_left"))
        {
            velocity.x = -moveSpeed;
            animatedSprite.FlipH = true;
            animatedSprite.Play("walk");
        }
        else if (Input.IsActionPressed("ui_right"))
        {
            velocity.x = moveSpeed;
            animatedSprite.FlipH = false;
            animatedSprite.Play("walk");
        }
        else
        {
            animatedSprite.Play("idle");
        }
        if (IsOnFloor())
        {
            isJumping = false;
            if (Input.IsActionPressed("jump"))
            {
                velocity.y = -jumpHeight;
                isJumping = true;
            }
        }
        if(!IsOnFloor() && isJumping)
        {
            animatedSprite.Play("jump");
        }

        if(isJumping)
        {
            jumpTime -= delta;
            if(jumpTime <= 0)
            {
                isJumping = false;
                jumpTime = jumpTimeReset;
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
