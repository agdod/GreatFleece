using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField] private CutSceneManager _cutSceneManager;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// Check that player collected keycard.
			if (GameManager.Instance.HasCard)
			{
				_cutSceneManager.EnableSuccess();
			}
			else
			{
				Debug.Log("Collect key card first");
			}
		}
	}
}
