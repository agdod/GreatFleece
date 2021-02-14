using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
   
    void Update()
    {
        // Rotate the camera every frame to kkep looking at player.
        transform.LookAt(_target);

    }
}
