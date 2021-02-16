using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
	[SerializeField] private CutSceneManager _cutSceneManager;

	private Animator _anim;

	private void Start()
	{
		_anim = GetComponentInParent <Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// Change the material
			MeshRenderer render = GetComponent<MeshRenderer>();
			Color color = new Color(0.2f, 0.03f, 0.02f, 0.2f); //(0.6f, 0.1f, 0.1f, 0.3f);
			render.material.SetColor("_TintColor", color);
			_anim.enabled = false;
			StartCoroutine(CutSceneDelay(0.5f));
		}
	}

	IEnumerator CutSceneDelay(float delay)
	{
		// 0.5 second delay before lunching cutscene
		yield return new WaitForSeconds(delay);
		_cutSceneManager.EnableCaptured();
	}
}
