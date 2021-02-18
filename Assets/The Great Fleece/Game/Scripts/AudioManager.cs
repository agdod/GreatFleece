using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _voiceOver;

    public void PlayVoiceOver(AudioClip audioClip)
	{
		_voiceOver.clip = audioClip;
		_voiceOver.Play();
	}

	public void StopVoiceOver()
	{
		_voiceOver.Stop();
	}
}
