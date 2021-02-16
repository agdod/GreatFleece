using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private CutSceneManager _cutSceneManager;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_cutSceneManager.EnableCaptured();
		}
	}
}
