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
        if(Input.IsActionPressed("ui_up"))
        {
            GD.Print("key pressed");
            velocity.y += 50;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
