using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	// Check for Trigger of Player
	// Update main camera to appropirate camera angle

	[SerializeField] private GameObject _cameraAngle;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// Assign camera.transform.position == postion of the right camera angle
			// Assigne the camera.transofmr.rotation == postion of the right camera rotation.
			Vector3 cameraPos;
			Vector3 cameraRot;

			// Enable tracking in inspector which is current camera angle
			cameraPos = _cameraAngle.transform.position;
			cameraRot =  _cameraAngle.transform.eulerAngles;

			Camera.main.transform.position = cameraPos;
			Camera.main.transform.rotation = Quaternion.Euler(cameraRot);
		}
	}
}
