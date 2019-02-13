using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridControl : MonoBehaviour 
{
	public GameObject missileIcon;
	public List<Image> icons = new List<Image>();
	public List<Image> blacklist = new List<Image>();

	public void AddIcon()
	{
		GameObject icon = Instantiate(missileIcon, transform.position, Quaternion.identity, this.transform);
		icon.GetComponent<Image>().fillAmount = 1.0f;
		icons.Add(icon.GetComponent<Image>());
	}

	public void AnimateAnIcon()
	{
		Image chosenIcon = GetLastAvailableImage();
		StartCoroutine(FillingAnimation(chosenIcon));
	}

	private IEnumerator FillingAnimation(Image icon)
	{
		float timer = 0.0f;
		float duration = ParametersMgr.instance.GetParameterFloat("projectileLifetime");
		while (timer <= duration)
		{
			icon.fillAmount = timer/duration;
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		icon.fillAmount = 1.0f;
		blacklist.Remove(icon);

		int blinkRepetition = 5;
		int count = 0;
		float blinkDuration = 0.1f;
		while (count < blinkRepetition)
		{
			icon.color = Color.green;
			yield return new WaitForSeconds(blinkDuration);
			icon.color = Color.white;
			count++;
		}
	}

	private Image GetLastAvailableImage()
	{
		for (int i = icons.Count - 1; i >= 0; --i)
		{
			if (!blacklist.Contains(icons[i]))
			{
				blacklist.Add(icons[i]);
				return icons[i];
			}
		}
		Debug.LogError("Unacceptable!");
		return null;
	}
}
