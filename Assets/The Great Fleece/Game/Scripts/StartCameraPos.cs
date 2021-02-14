using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraPos : MonoBehaviour
{
	[SerializeField] private bool _isStartCam;

	private void Start()
	{
		if (_isStartCam)
		{
			Camera.main.transform.position = this.transform.position;
			Camera.main.transform.rotation = this.transform.rotation;
		}
	}
}
