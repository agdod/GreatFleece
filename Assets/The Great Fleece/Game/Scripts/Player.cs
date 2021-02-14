using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;

	private void Start()
	{
		// Collect the navmesh agent component
		_agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		// Get left mouse button click
		if (Input.GetMouseButtonDown(0))
		{
			RayCastPosition();
		}
	}

	void RayCastPosition()
	{
		// Cast a ray from mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			// Debug the floor position
			Debug.Log("hit at :" + hit.point);
			_agent.SetDestination(hit.point);
			Debug.DrawLine(ray.origin, hit.point);
		}
	}
}
