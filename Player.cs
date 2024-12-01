using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public  float speed = 300.0f;
	AnimationPlayer animacion;

	public override void _Ready()
	{
			animacion = this.GetNode<AnimationPlayer>("Animacion");

	}


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		

		//Movimiento
		Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();
		if (direction != Vector2.Zero)
		{
			velocity = direction * speed;
		}
		else
		{
			if (!animacion.IsPlaying()){
				animacion.Play("Idle");
			}
			
			velocity = Vector2.Zero;
		}

		Velocity = velocity;
		MoveAndSlide();


		//golpe
		if (Input.IsActionJustPressed("golpe")){

				animacion.Play("Swing");
		}
	}
}


		// public const float JumpVelocity = -400.0f;

		// // Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// {
		// 	velocity.Y = JumpVelocity;
		// }
