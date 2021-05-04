using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Platform[] platforms;
    void Update()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            Vector3 ballPixelPosition = Camera.main.WorldToScreenPoint(platforms[i].transform.position);
            if (ballPixelPosition.y <= Screen.height)
            {
                transform.position = new Vector3(transform.position.x, (platforms[i].transform.transform.position.y) + 3, transform.position.z);
            }
            
        }
    }
}
