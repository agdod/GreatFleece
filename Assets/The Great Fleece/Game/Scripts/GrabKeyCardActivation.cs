using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
	[SerializeField] private CutSceneManager _cutSceneManager;
	[SerializeField] private GameObject _keyCard;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("trigger sleeping guard");
		if (other.tag == "Player")
		{
			// disable the card from the GO.
			_keyCard.SetActive(false);
			_cutSceneManager.EnableSleepingGuard();
		}
	}
}
