using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelVoiceOver : MonoBehaviour
{
	private void OnEnable()
	{
		GameManager.Instance.Audio.StopVoiceOver();
	}
}
