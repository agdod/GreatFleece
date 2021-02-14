using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	/* if left click
     * cast a ray from the mouse postion
     * debug the floor position
     * create an object at the floor postion
     * */

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
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Debug.Log("hit at :" + hit.point);
			Debug.DrawLine(ray.origin, hit.point);
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = hit.point;
		}
	}
}
