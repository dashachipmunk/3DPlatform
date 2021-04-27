using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    float horizontal;
    [SerializeField] float rotationSpeed;
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X");
        transform.RotateAround(transform.position, Vector3.up, horizontal * rotationSpeed);
        if (Ball.singleton.isEnded)
        {
            Time.timeScale = 0f;
            
        }
    }
}
