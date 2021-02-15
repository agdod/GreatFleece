using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
	// Create the ability to detect the player - Darren, when hes caught in the fiedl of view
	// on tirgger enter
	// Check its darren from player tag
	// Enable game OverCutscene

	private CutSceneManager _cutSceneManager;

	private void Start()
	{
		_cutSceneManager = FindObjectOfType<CutSceneManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("TRiggered by : " + other);
		if (other.tag =="Player")
		{
			// Enable cut scene
			_cutSceneManager.EnableCaptured();
		}
	}

}
