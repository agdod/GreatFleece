using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
	[SerializeField] private List<Transform> _wayPoints;
	[SerializeField] private NavMeshAgent _navAgent;
	private Animator _anim;
	private bool _reverse;
	private bool _targetReached;
	private int _wayPointIndex = 0;

	private void Start()
	{
		_navAgent = GetComponent<NavMeshAgent>();
		if (_navAgent == null)
		{
			Debug.LogError("NavMeshAgent not found.");
		}
		_anim = GetComponent<Animator>();
		if(_anim == null)
		{
			Debug.LogError("Animator not found.");
		}

		_targetReached = false;

		//If no waypoint set for guard default to idle
		if (_wayPoints.Count == 0 || _wayPoints[0] == null)
		{
			_targetReached = true;
			if (_anim !=null)
			{
				_anim.SetBool("isWalking", false);
			}
		}
	}

	private void Update()
	{
		if (_targetReached == false)
		{
			if (_anim != null)
			{
				_anim.SetBool("isWalking", true);
			}
			MoveGuard();
		}
	}

	void MoveGuard()
	{
		if (_wayPoints.Count > 0 && _wayPoints[_wayPointIndex] != null)
		{
			if (_navAgent != null)
			{
				_navAgent.SetDestination(_wayPoints[_wayPointIndex].position);
			}

			// has guard arrived at current target

			float distance = Vector3.Distance(transform.position, _wayPoints[_wayPointIndex].position);
			if (distance < 1.0f && _targetReached == false)
			{
				Debug.Log("target reached");

				// Idle guard pause if at start or end of way points
				if (_wayPointIndex == 0 || _wayPointIndex == _wayPoints.Count - 1)
				{
					IdleGuardControl();
				}

				// if guard has arrived set next target
				UpDateWayPoint();
			}
		}
	}

	void AnimateGuard()
	{
		_anim.SetBool("isWalking", true);

	}

	void IdleGuardControl()
	{
		float pause;

		_targetReached = true;
		pause = Random.Range(2, 5.0f);
		if (_anim != null)
		{
			_anim.SetBool("isWalking", false);
		}
		StartCoroutine(WaitToMove(pause));
	}

	void UpDateWayPoint()
	{
		if (!_reverse)
		{
			if (_wayPointIndex < _wayPoints.Count)
			{
				_wayPointIndex++;
				if (_wayPointIndex == _wayPoints.Count)
				{
					_reverse = true;
				}
			}
		}
		if (_reverse)
		{
			if (_wayPointIndex > 0)
			{
				_wayPointIndex--;
				if (_wayPointIndex == 0)
				{
					_reverse = false;
				}
			}
		}
	}

	IEnumerator WaitToMove(float delay)
	{
		yield return new WaitForSeconds(delay);
		_targetReached = false;
	}
}
