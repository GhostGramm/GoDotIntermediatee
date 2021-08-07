using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 velocity = new Vector2(0,0);
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if(Input.IsActionJustPressed("ui_up"))
        {
            velocity.y = -50;
        }
        if(Input.IsActionJustPressed("ui_down"))
        {
            velocity.y = 50;
        }
        if(Input.IsActionJustPressed("ui_left"))
        {
            velocity.x = -50;
        }
        if(Input.IsActionJustPressed("ui_right"))
        {
            velocity.x = 50;
        }
        MoveAndSlide(velocity);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
