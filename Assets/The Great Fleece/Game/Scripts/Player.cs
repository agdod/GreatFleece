using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _anim;

	private bool _hasArrived;
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

	void Update()
	{
		// Get left mouse button click
		if (Input.GetMouseButtonDown(0))
		{
			RayCastPosition();
		}
		CheckPlayerPosition();
	}

	void RayCastPosition()
	{
		// Cast a ray from mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			// Debug the floor position
			// Debug.Log("hit at :" + hit.point);
			_destination = hit.point;
			// As player isnt climbing y-axis serves no purpose (floor could be higher or lower)
			_destination.y = 0;
			_agent.SetDestination(_destination);

			// Start to move the Player, player isnt at destination
			CheckPlayerPosition();
		}
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

}
