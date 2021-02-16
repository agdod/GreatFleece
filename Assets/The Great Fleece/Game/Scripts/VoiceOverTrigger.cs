using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioVO;
	[SerializeField] private bool _playOnce;

	private void Start()
	{
		_audioVO = GetComponent<AudioSource>();
		_playOnce = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!_playOnce)
			{
				_audioVO.Play();
				_playOnce = true;
			}
			
		}
	}
}
