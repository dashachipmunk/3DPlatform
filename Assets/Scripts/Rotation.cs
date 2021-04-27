using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float angle;
    void Start()
    {
        transform.RotateAround(transform.position, Vector3.up, Random.Range(0, angle));
    }
}
