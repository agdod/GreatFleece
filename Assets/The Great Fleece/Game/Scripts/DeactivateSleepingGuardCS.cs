using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSleepingGuardCS : MonoBehaviour
{
	[SerializeField] private GameObject _sleepingGuardCS;
	[SerializeField] private GameObject _UIScene;
	private void OnEnable()
	{
		StartCoroutine(Pause());
	}

	IEnumerator Pause()
	{
		yield return new WaitForSeconds(0.034f);
		Debug.Log("Activated - deactiving sleeping guard CS!");
		_sleepingGuardCS.SetActive(false);
		_UIScene.SetActive(false);
	}
}
