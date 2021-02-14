using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	// Check for Trigger of Player
	// Update main camera to appropirate camera angle

	// debug.log trigger activated

	[SerializeField] private GameObject[] _cameraAngles;
	[SerializeField] private GameObject[] _cameraTriggers;
	[SerializeField] private int _cameraIndex;

	private void Start()
	{
		string thisTrigger = this.gameObject.name;
		
		for (int i = 0; i < _cameraTriggers.Length; i++)
		{
			if (thisTrigger == _cameraTriggers[i].name)
			{
				_cameraIndex = i;
				break;
			}
		}
		Debug.Log("thisTrigger , index : " + thisTrigger+","+_cameraIndex);
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Trigger activated");

			// Assign camera.transform.position == postion of the right camera angle
			// Assigne the camera.transofmr.rotation == postion of the right camera rotation.
			Vector3 cameraPos;
			Quaternion camQuaternion;
			Vector3 cameraRot;

			cameraPos = _cameraAngles[_cameraIndex].transform.position;
			cameraRot =  _cameraAngles[_cameraIndex].transform.eulerAngles;

			Debug.Log("camera angle " + _cameraAngles[_cameraIndex].name);

			Debug.Log("Camera : " + _cameraIndex);
			Debug.Log("CameraProgressionAngles : " + _cameraAngles[_cameraIndex].transform.rotation);
			Debug.Log("Postions , Roations : " + cameraPos + "," + cameraRot);
			Camera.main.transform.InverseTransformPoint(cameraPos);
			Camera.main.transform.rotation = Quaternion.EulerAngles(cameraRot);
		}
	}
}
