using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitorPowerUp : Orbitor
{
	public AudioClip spawn;
	public AudioClip getPowerUp;

	private float lifeDuration = 20.0f;

	public void Setup(float x, float y)
	{
		circleX = x;
		circleY = y;
	}

	protected override void Start()
    {
		base.Start();
		globe = GameObject.Find("Earth").transform;
		transform.up = transform.position - globe.position;
;		StartCoroutine(DespawnTimer());
		lifeDuration = ParametersMgr.instance.GetParameterFloat("powerUpLifetime");
		SoundManager2D.instance.PlayClip(spawn);
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
			SoundManager2D.instance.PlayClip(getPowerUp);
			other.gameObject.GetComponent<OrbitorPlayer>().IncreaseNbMaxMissile();
			Destroy(this.gameObject);
		}
	}
}
