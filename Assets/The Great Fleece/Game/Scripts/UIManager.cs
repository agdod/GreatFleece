using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public void OnRestart()
	{
		// Reload current scene to restart - only one scene so scene index is 0
		SceneManager.LoadScene(0);
	}

	public void OnQuit()
	{
		Application.Quit();
	}
}
