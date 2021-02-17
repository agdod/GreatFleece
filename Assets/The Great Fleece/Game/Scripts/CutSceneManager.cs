using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
	public enum CutScene
	{
		Intro = 0,
		SleepingGuard = 1,
		Captured = 2,
		Success = 3
	}

	[SerializeField] private CutScene _cutScene;

	[SerializeField] private GameObject _UIMenu;

	// *** NOTE : Ensure Cutscenes are added to _cutSceneList in SAME order as the enums ***
	[SerializeField] private List<GameObject> _cutSceneList;

	/*
	[SerializeField] private GameObject _cutSceneIntro;
	[SerializeField] private GameObject _cutSceneSleepingGuard;
	[SerializeField] private GameObject _cutSceneCaptured;
	[SerializeField] private GameObject _cutSceneSuccess;
	*/

	private bool _cutScenePlaying;
	private int _cutSceneIndex;
	private CutScene _currentCutScene;

	void SkipCutScene()
	{
		// Get the playable director of cutscene
		// get the lenght of playable asset 

		PlayableDirector director = _cutSceneList[(int)_currentCutScene].GetComponent<PlayableDirector>();
		double csLength = director.playableAsset.duration;

		// Skip to end of timeline - 
		//			0.01 seconds from end to ensure getting final shot, and activation of Player, deactivation of Actors and timeline.
		double skipTo = csLength - 0.01f;
		director.time = skipTo;
	}

	private void Start()
	{
		_cutScenePlaying = false;
	}

	private void Update()
	{
		if (_cutScenePlaying == true)
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				SkipCutScene();
			}
			// Possible to add pause and resume function to cutscene.
		}
	}

	public void CutSceneCompleted()
	{
		_cutScenePlaying = false;
	}

	/* *** Activate the required CutScene, set it as current *** 
	 * *** Make sure all other CutScene are inactive before activating */

	private void DiableAllOthers() 
	// Checks and make sure all other CutScene are disbled before activating current cutscene
	{
		for(int i = 0; i < _cutSceneList.Count; i++)
		{
			if ((int)_currentCutScene != i)
			{
				Debug.Log("current cut scene " + (int)_currentCutScene);
				_cutSceneList[i].SetActive(false);
			}
		}
	}

	public void EnableIntro()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Intro;
		DiableAllOthers();
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Intro].SetActive(true);
	}

	public void EnableCaptured()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Captured;
		DiableAllOthers();
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Captured].SetActive(true);
	}

	public void EnableSleepingGuard()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.SleepingGuard;
		DiableAllOthers();
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.SleepingGuard].SetActive(true);
	}

	public void EnableSuccess()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Success;
		DiableAllOthers();
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Success].SetActive(true);
	}
}
