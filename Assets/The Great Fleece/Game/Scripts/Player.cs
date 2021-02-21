using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField] private GameObject _coinPrefab;
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _anim;
	[SerializeField] private GuardController _guardController;
	[SerializeField] private GameObject _newPostion; // Position after Sleeping Guard Cutscene

	private float distance;
	private bool _coinTossed = false;
	private Vector3 _destination;
	
	private void Start()
	{
		// Collect the navmesh agent component
		_agent = GetComponent<NavMeshAgent>();
		// Collect the animator
		_anim = GetComponentInChildren<Animator>();
		_anim.SetBool("isWalk", false);

		// Init destination 
		_destination = transform.position;
	}

	private void OnEnable()
	{
		// Freeze player movement by assigning its destination to its current tranform postion
		_destination = transform.position;
	}

	void Update()
	{
		// Get left mouse button click
		if (Input.GetMouseButtonDown(0))
		{
			RayCastPosition(true);
		}
		if (Input.GetMouseButtonDown(1))
		{
			if (!_coinTossed )
			{
				_anim.SetTrigger("Throw");
				// Add 0.5s delay before instantie coin to fit more wiht animation
				RayCastPosition(false);
			}
			
		}
		CheckPlayerPosition();
	}

	void GetAnimationState()
	{
		// Collect current animation state to return to after throw
		
	}

	void RayCastPosition(bool player)
	{
		// if player is true left mouse button was clikced and player is moved
		// else right mouse button was clicked and coin is tossed
		
		// Cast a ray from mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			if (player)
			{
				MovePlayer(hit.point);
			}
			else
			{
				CoinToss(hit.point);
			}
		}
	}

	void CoinToss(Vector3 tossToPos)
	{
		_coinTossed = true;
		if (_coinPrefab != null)
		{
			Instantiate(_coinPrefab, tossToPos, Quaternion.identity);
			SendAIsToCoinSpot(tossToPos);
		}
		
	}

	void MovePlayer(Vector3 moveToPos)
	{
		_destination = moveToPos;

		//Start to move the player
		_agent.SetDestination(_destination);
		//Check if player has arrived at destination
		CheckPlayerPosition();
	}

	void CheckPlayerPosition()
	{
		// if player has arrived at destination
		distance = Vector3.Distance(transform.position,_destination);
		if (distance < 2.0f)
		{
			// player is idle at destination
			_anim.SetBool("isWalk", false);
		}
		else
		{
			// Player has not arrived carry on walking
			_anim.SetBool("isWalk", true);
		}
	}
	
	void SendAIsToCoinSpot(Vector3 position)
	{
		if (_guardController != null)
		{
			_guardController.DistractGuards(position);
		}
	}

	public void RepositonPlayer()
	{
		// Repostion player for after Sleeping Guard CutScene
		transform.position = _newPostion.transform.position;
		transform.rotation = _newPostion.transform.rotation;
	}
}
