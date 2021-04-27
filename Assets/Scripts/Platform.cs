using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float platformPos = transform.position.y;
        float ballPos = Ball.singleton.transform.position.y;
        float distance = ballPos - platformPos;
        if (distance < -0.1f)
        {
            animator.SetBool("isDestroyed", true);
            StartCoroutine(Wait(0.7f));
        }
    }
    IEnumerator Wait(float wait)
    {
        yield return new WaitForSeconds(wait);
        Ball.singleton.score++;
        Destroy(gameObject);
    }
}

