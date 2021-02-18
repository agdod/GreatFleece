using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    // Call Coroutine to load main scene
    // Create an async operation = loadSceneAsync("game")
    // while operation isnt complete
    //   progress bar fill amount = operation progress
    // yield wait for end of frame

    [SerializeField] private Image _fillImage;

	private void Start()
	{
        StartCoroutine(AsyncLoadGameScene());
	}

    IEnumerator AsyncLoadGameScene()
	{
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        while (!asyncLoad.isDone)
		{
            _fillImage.fillAmount = asyncLoad.progress;
            yield return new WaitForEndOfFrame();
        }
	}
}
