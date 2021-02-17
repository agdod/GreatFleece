using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Finish : MonoBehaviour
{
	private void OnEnable()
	{
		GameManager.Instance.CSManager.CutSceneCompleted();
	}
}
