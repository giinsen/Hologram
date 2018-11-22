using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorPowerUp : Orbitor
{
	public float lifeDuration = 20.0f;


	public void Setup(float x, float y)
	{
		circleX = x;
		circleY = y;
	}

	private void Start()
	{
		StartCoroutine(DespawnTimer());
	}

	private IEnumerator DespawnTimer()
	{
		yield return new WaitForSeconds(lifeDuration);
		if (this != null)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//Power-up Player
			Destroy(this.gameObject);
		}
	}
}
