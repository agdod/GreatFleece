using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("LoadingScene");
	}

	public void OnRestart()
	{
		// Reload current scene to restart - only one scene so scene index is 0
		SceneManager.LoadScene("Game");
	}

	public void OnQuit()
	{
		Application.Quit();
	}
}
