using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float speed = 300.0f;
	AnimationPlayer animacion;
	Node2D palo;

	int tipoAnimacion;

	bool fCorrer, fIdle, fAtaque;

	public override void _Ready()
	{

		animacion = this.GetNode<AnimationPlayer>("Animacion");
		palo = this.GetNode<Node2D>("HandEquip");
		animacion.Play("Idle");
		palo.Visible = false;


	}


	public override void _PhysicsProcess(double delta)
	{

		Vector2 velocity = Velocity;


		//Movimiento
		Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();
		if (direction.X > 0){
			this.GetNode<Sprite2D>("Body").FlipH = false;
			this.GetNode<Node2D>("HandEquip").Scale = new Vector2(1,1);
		}	
		if (direction.X < 0){
			this.GetNode<Sprite2D>("Body").FlipH = true;
			this.GetNode<Node2D>("HandEquip").Scale = new Vector2(-1,1);
		}
			

		//golpe
		if (Input.IsActionJustPressed("golpe"))
		{
			tipoAnimacion = 2;
			fAtaque = true;
			palo.Visible = true;
		}
		else
		{
			if (direction != Vector2.Zero && animacion.CurrentAnimation != "Swing")
			{

				velocity = direction * speed;
				tipoAnimacion = 1;
				palo.Visible = false;


			}
			else
			{
				velocity = Vector2.Zero;
				if (!animacion.IsPlaying())
				{
					tipoAnimacion = 0;
					palo.Visible = false;

				}
			}
		}

		switch (tipoAnimacion)
		{
			case 1:
				animacion.Play("Correr");
				break;
			case 2:
				animacion.Play("Swing");
				break;
			default:
				animacion.Play("Idle");
				break;
		}

		Velocity = velocity;
		MoveAndSlide();



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
