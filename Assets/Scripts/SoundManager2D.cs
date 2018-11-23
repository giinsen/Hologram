using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2D : MonoBehaviour 
{
	public static SoundManager2D instance;

	private AudioSource source;

	private void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}

		source = GetComponent<AudioSource>();
	}

	public void PlayClip(AudioClip clip)
	{
		source.clip = clip;
		source.Play();
	}

	public void MultiSound(AudioClip[] clips, float pitchVariation = 0.0f)
	{
		AudioClip chosenClip = clips[Random.Range(0, clips.Length)];
		source.clip = chosenClip;
		source.pitch += Random.Range(-pitchVariation, +pitchVariation);
		source.Play();
	}
}
