using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// *** Singleton Pattern ***

	private static GameManager _instance;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("GameManager is null!");

			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
	}

	// *** End of Singleton Pattern ***

	[SerializeField] private AudioManager _audioManager;
	[SerializeField] private CutSceneManager _cutSceneManager;
	[SerializeField] private bool _hasCard;

	[SerializeField] private bool _playIntro;

	public bool HasCard
	{
		get { return _hasCard; }
		set { _hasCard = value; }
	}

	public CutSceneManager CSManager
	{
		get { return _cutSceneManager; }
	}

	public AudioManager Audio
	{
		get { return _audioManager; }
	}

	private void Start()
	{
		// Initialise the game enusre players and correct scenes are loaded.
		if (_playIntro)
		{
			_cutSceneManager.EnableIntro();
		}

	}
}
