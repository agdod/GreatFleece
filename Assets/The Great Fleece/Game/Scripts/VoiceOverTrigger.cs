using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
	[SerializeField] private AudioClip _audioVO;
	[SerializeField] private bool _playOnce;

	private void Start()
	{
		_playOnce = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!_playOnce)
			{
				GameManager.Instance.Audio.PlayVoiceOver(_audioVO);
				_playOnce = true;
			}

		}
	}
}
