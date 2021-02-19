using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
	[SerializeField] private CutSceneManager _cutSceneManager;
	[SerializeField] private GameObject _keyCard;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// disable the card from the Sleeping Guard GO.
			_keyCard.SetActive(false);
			GameManager.Instance.HasCard = true;
			// Repostion Player ready for exit of CutScene.
			other.GetComponent<Player>().RepositonPlayer();
			_cutSceneManager.EnableSleepingGuard();
		}
	}
}
