using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorMissile : Orbitor 
{
	public float speed = 5.0f;
	public bool die = false; 

	private Vector2 initialInput;

	public void SetInput(Vector2 input)
	{
		initialInput = input;
	}

	protected override void Update()
	{
		base.Update();
		Move(-initialInput.y, initialInput.x, speed, false);
	}

	private void OnCollisionEnter(Collision other)
	{
		
	}
}