using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorMissile : Orbitor 
{
	public float speed = 5.0f;
	public bool die = false; 
	public float timeBeforeDeath = 10.0f;
	public float initialTime = 0.2f;

    public GameObject myShooterParent;

	private Vector2 initialInput;
	private bool lethal = false;

	private void Start()
	{
		if (globe == null)
		{
			globe = GameObject.Find("Earth").transform;
		}

		StartCoroutine(LethalCD());
		if (die)
		{
			StartCoroutine(DieCD());
		}
	}

	private IEnumerator LethalCD()
	{
		yield return new WaitForSeconds(initialTime);
		lethal = true;
	}

	private IEnumerator DieCD()
	{
		yield return new WaitForSeconds(timeBeforeDeath);
		if (this != null)
		{
			Destroy(this.gameObject);
            myShooterParent.GetComponent<OrbitorPlayer>().currentLivingMissile--;
		}
	}

	public void SetInput(Vector2 input)
	{
		initialInput = input.normalized;
	}

	public void SetInitialPosition(float x, float y)
	{
		circleX = x;
		circleY = y;
	}

	protected override void Update()
	{
		base.Update();
		Move(initialInput.y, -initialInput.x, speed, false);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player" && lethal)
		{
			other.collider.GetComponent<OrbitorPlayer>().Hit();
            myShooterParent.GetComponent<OrbitorPlayer>().currentLivingMissile--;
            Destroy(this.gameObject);
		}
	}
}