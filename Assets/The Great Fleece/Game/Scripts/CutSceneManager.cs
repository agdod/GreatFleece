using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _UIMenu;
    [SerializeField] private GameObject _cutSceneIntro;
    [SerializeField] private GameObject _cutSceneSleepingGuard;
    [SerializeField] private GameObject _cutSceneCaptured;
    [SerializeField] private GameObject _cutSceneSuccess;

    public void EnableCaptured()
	{
        _UIMenu.SetActive(true);
        _cutSceneCaptured.SetActive(true);
	}
}
