using Godot;
using System;

public partial class Personaje : AnimatedSprite2D
{
	public float velocidad = 3.0f;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		bool flag = false;
		Vector2 aux = new Vector2(0, 0);
		if (Input.IsKeyPressed(Key.D))
		{
			aux.X = velocidad;
			flag = true;
			this.FlipH = false;
			//this.Position += new Vector2(velocidad, 0);
		}
		if (Input.IsKeyPressed(Key.A))
		{
			aux.X = -velocidad;
			flag = true;
			this.FlipH = true;
			//this.Position += new Vector2(-velocidad, 0);
		}
		if (Input.IsKeyPressed(Key.W))
		{
			aux.Y = -velocidad;
			flag = true;
			//this.Position += new Vector2(0, -velocidad);
		}
		if (Input.IsKeyPressed(Key.S))
		{
			aux.Y = velocidad;
			flag = true;
			//this.Position += new Vector2(0, velocidad);
		}
		if (flag)
		{
			this.Position += aux.Normalized();
			this.Play("Correr");
		}


		if (!Input.IsKeyPressed(Key.S) && !Input.IsKeyPressed(Key.D) && !Input.IsKeyPressed(Key.W) && !Input.IsKeyPressed(Key.A))
		{
			this.Play("Idle");
		}

	}
}
