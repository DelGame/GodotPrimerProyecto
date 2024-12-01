using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float speed = 300.0f;
	AnimationPlayer animacion;
	Node2D palo;

	bool fCorrer, fIdle, fAtaque;

	public override void _Ready()
	{
	
		animacion = this.GetNode<AnimationPlayer>("Animacion");
		palo = this.GetNode<Node2D>("HandEquip");
		animacion.Play("Idle");

	}


	public override void _PhysicsProcess(double delta)
	{

		Vector2 velocity = Velocity;


		//Movimiento
		Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();

		if (direction != Vector2.Zero)
		{
			velocity = direction * speed;
			palo.Visible = false;
			fCorrer = true;
		}
		else
		{
			fIdle = true;
			palo.Visible = false;
			velocity = Vector2.Zero;
		}

		Velocity = velocity;
		MoveAndSlide();


		//golpe
		if (Input.IsActionJustPressed("golpe"))
		{
			fAtaque = true;
			palo.Visible = true;
		}

	}
}


// public const float JumpVelocity = -400.0f;

// // Handle Jump.
// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
// {
// 	velocity.Y = JumpVelocity;
// }




// if(fAtaque){
// 	animacion.Play("Swing");
// } else if (fCorrer && !animacion.IsPlaying()){
// 	animacion.Play("Correr");
// } else if (fIdle && !animacion.IsPlaying()){
// 	animacion.Play("Idle");
// }
// fAtaque = false;
// fCorrer = false;
// fIdle = false;

