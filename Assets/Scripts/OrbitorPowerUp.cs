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

	protected override void Start()
    {
		base.Start();
		StartCoroutine(DespawnTimer());
		lifeDuration = ParametersMgr.instance.GetParameterFloat("powerUpLifetime");
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
			other.gameObject.GetComponent<OrbitorPlayer>().IncreaseNbMaxMissile();
			Destroy(this.gameObject);
		}
	}
}
