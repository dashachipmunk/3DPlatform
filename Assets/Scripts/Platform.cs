using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Animator animator;
    public MeshCollider[] meshColliders;
    private AudioSource audioSource;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float platformPos = transform.position.y;
        float ballPos = Ball.singleton.transform.position.y;
        float distance = ballPos - platformPos;
        if (distance < -0.1f)
        {
            animator.SetBool("isDestroyed", true);
            audioSource.Play();
            ColliderOff();
        }
    }

    public void DestroyPlatform()
    {
        Ball.singleton.score++;
        Destroy(gameObject);
    }

    public void ColliderOff()
    {
        for (int i = 0; i < meshColliders.Length; i++)
        {
            meshColliders[i].enabled = false;
        }
    }
}

