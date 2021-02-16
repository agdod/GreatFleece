using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    // for sending batch commands to all guards
    [SerializeField] private GuardAI[] _guardAIs;

	private void Start()
	{
		_guardAIs = GetComponentsInChildren<GuardAI>();
	}

	public void DistractGuards(Vector3 position)
	{
		foreach(GuardAI guard in _guardAIs)
		{
			guard.DistractGuard(position);
		}
	}
}
