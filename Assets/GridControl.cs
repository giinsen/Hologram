using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridControl : MonoBehaviour 
{
	public GameObject missileIcon;

	private List<Slider> icons = new List<Slider>();
	private List<Coroutine> routines = new List<Coroutine>();

	private int cursor = -1;

	public void LaunchCD()
	{
		cursor ++;
		routines[cursor] = StartCoroutine(Cooldown(icons[cursor]));
	}

	public void StopCD()
	{
		StopCoroutine(routines[cursor]);
		icons[cursor].value = 1.0f;
		cursor --;
	}

	private IEnumerator Cooldown(Slider slider)
	{
		float duration = ParametersMgr.instance.GetParameterFloat("projectileLifetime");
		float timer = 0.0f;
		while (timer < duration)
		{
			slider.value = timer/duration;
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		slider.value = 1.0f;
		cursor --;
	}

	public void AddMissile()
	{
		GameObject go = Instantiate(missileIcon);
		go.transform.SetParent(transform);
		icons.Add(go.GetComponent<Slider>());
	}
}
