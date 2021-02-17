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

		// Skip to end of timeline - 0.5seconds from end to get the fade in effect
		double skipTo = csLength - 0.5f;
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

	/* *** Set the current cutscene and playback *** */

	public void EnableIntro()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Intro;
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Intro].SetActive(true);
		//_cutSceneIntro.SetActive(true);
	}

	public void EnableCaptured()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Captured;
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Captured].SetActive(true);
		//_cutSceneCaptured.SetActive(true);
	}

	public void EnableSleepingGuard()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.SleepingGuard;
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.SleepingGuard].SetActive(true);
		//_cutSceneSleepingGuard.SetActive(true);
	}

	public void EnableSuccess()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Success;
		_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Success].SetActive(true);
		//_cutSceneSuccess.SetActive(true);
	}
}
