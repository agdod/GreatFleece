using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private Transform _startCam;

	private void Start()
	{
		Camera.main.transform.position = _startCam.transform.position;
		Camera.main.transform.rotation = _startCam.transform.rotation;
	}

	void Update()
	{
		// Rotate the camera every frame to kkep looking at player.
		transform.LookAt(_target);

	}
}
