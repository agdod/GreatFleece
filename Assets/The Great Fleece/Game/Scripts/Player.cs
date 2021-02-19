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

		// ***
		// *** Alternative check for distance between player and target
		// *** using vector3.distance , and check if its less than 1
		// ***
		
		// Floor Hit from raycast is 1 d.p
		// Convert float to double and round to 1 d.p

		double xPos = System.Math.Round(transform.position.x,1);
		double zPos = System.Math.Round(transform.position.z,1);

		double destinationX = System.Math.Round(_destination.x, 1);
		double destinationZ = System.Math.Round(_destination.z, 1);

		// Debug.Log("xPos,zPos : " + xPos + "," + zPos);
		if(xPos == destinationX && zPos == destinationZ)
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
