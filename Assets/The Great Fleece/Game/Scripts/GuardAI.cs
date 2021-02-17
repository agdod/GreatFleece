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
	private bool _foundCoin = false;
	private bool _isDistracted = false;
	private Vector3 _distractPos;
	private int _wayPointIndex = 0;

	private void Start()
	{
		_navAgent = GetComponent<NavMeshAgent>();
		if (_navAgent == null)
		{
			Debug.LogError("NavMeshAgent not found.");
		}
		_anim = GetComponent<Animator>();
		if (_anim == null)
		{
			Debug.LogError("Animator not found.");
		}

		_targetReached = false;

		//If no waypoint set for guard default to idle, set waypoint[0] to current position
		if (_wayPoints.Count == 0 || _wayPoints[0] == null)
		{
			_targetReached = true;
			if (_anim != null)
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
			if (!_isDistracted)
			{
				MoveGuard();
			}
			else if (_isDistracted)
			{
				MoveDistractedGuard();
			}
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

				// Idle guard pause if at start or end of way points
				if (_wayPointIndex == 0 || _wayPointIndex == _wayPoints.Count - 1)
				{
					IdleGuardControl();
				}

				// Check guard isnt stationary , i.e has more than one way point
				if (_wayPoints.Count > 1)
				{
					// Update next waypoint for guard
					UpDateWayPoint();
				}
			}
		}
	}

	void MoveDistractedGuard()
	{
		// Move Distracted guard to coin spot location (_distractPos)

		if (_navAgent != null)
		{
			_navAgent.SetDestination(_distractPos);
		}
		float distance = Vector3.Distance(transform.position, _distractPos);
		if (distance < 2.0f && _targetReached == false)
		{
			Debug.Log("Coin spot distraction reached");
			_foundCoin = true;
			IdleGuardControl();
		}
	}

	void IdleGuardControl()
	{
		// Guard set to idle 
		// Active coroutine to wait

		float pause;
		_targetReached = true;
		pause = Random.Range(2, 5.0f);
		if (_anim != null)
		{
			_anim.SetBool("isWalking", false);
		}

		// Check Guard isnt Stationary - i.e has more than one waypoint - 
		// If guard is distract - i.e coin toss, 

		if (_wayPoints.Count > 1 || _isDistracted)
		{
			StartCoroutine(WaitToMove(pause));
		}
		else if (_wayPoints.Count == 1 && !_isDistracted)
		{
			RoatateGuard();
		}
	}

	void RoatateGuard()
	{
		// rotate guard back to starting roation

		Debug.Log("Back to stationary mode");
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

		// When coroutnine is finished guard exits idle wait, and makes way to next target

		// Reset target after idle wait at coin
		if (_isDistracted && _foundCoin)
		{
			_targetReached = false;
		}

		// if guard was distracted return to normal duties - ie no longer distracted
		if (_isDistracted && _foundCoin)
		{
			_isDistracted = false;
		}

		// If guard wasnt distracted reset targetReached
		if (!_isDistracted)
		{
			_targetReached = false;
		}
	}

	public void DistractGuard(Vector3 moveToPos)
	{
		// Setup for distaction of guard
		_distractPos = moveToPos;
		_isDistracted = true;
		_targetReached = false;
		// Stop WaitToMove coroutine, so guard doesnt lose focus on distraction

		StopCoroutine(WaitToMove(0));
	}
}
