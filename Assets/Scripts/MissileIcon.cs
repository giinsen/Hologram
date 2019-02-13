using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileIcon : MonoBehaviour 
{
	private Slider slider;

	private void Start()
	{
		slider = GetComponent<Slider>();
		slider.value = 1.0f;
	}

	public void StartCooldown()
	{
		
	}


}
