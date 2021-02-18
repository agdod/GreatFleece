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

	private bool _cutScenePlaying;
	private int _cutSceneIndex;
	private CutScene _currentCutScene;

	private void Start()
	{
		_cutScenePlaying = false;
		DisableAll();
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

	private void SkipCutScene()
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

	private void DisableAll()
	// Checks and make sure all CutScene are disbled.
	{
		_UIMenu.SetActive(false);
		for (int i = 0; i < _cutSceneList.Count; i++)
		{
			_cutSceneList[i].SetActive(false);
		}
	}

	public void CutSceneCompleted()
	{
		_cutScenePlaying = false;
	}

	/* *** Activate the required CutScene, set it as current *** 
	 * *** Make sure all other CutScene are inactive before activating */

	public void EnableIntro()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Intro;
		//_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Intro].SetActive(true);
	}

	public void EnableCaptured()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Captured;
		//_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Captured].SetActive(true);
	}

	public void EnableSleepingGuard()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.SleepingGuard;
		//_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.SleepingGuard].SetActive(true);
	}

	public void EnableSuccess()
	{
		_cutScenePlaying = true;
		_currentCutScene = CutScene.Success;
		//_UIMenu.SetActive(true);
		_cutSceneList[(int)CutScene.Success].SetActive(true);
	}
}
