using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 velocity = new Vector2(0,0);
    private int moveSpeed = 100;
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if(Input.IsActionPressed("ui_left"))
        {
            velocity.x = -moveSpeed;
        }
        if(Input.IsActionPressed("ui_right"))
        {
            velocity.x = moveSpeed;
        }
        MoveAndSlide(velocity);

        velocity.x = Mathf.Lerp(velocity.x,0,0.1f);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
