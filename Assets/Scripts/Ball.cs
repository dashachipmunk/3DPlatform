using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Ball : MonoBehaviour
{
    public static Ball singleton { get; set; }
    public BallState ballState;
    public float maxSpeed;
    public int score;
    public TextMeshProUGUI scoreText;
    public bool isEnded;
    Rigidbody rb;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public enum BallState
    {
        FALL,
        JUMP
    }
    private void Awake()
    {
        singleton = this;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        ballState = BallState.JUMP;
    }

    void Update()
    {
        if (rb.velocity.magnitude >= 11f)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        scoreText.text = score.ToString();
        PauseGame();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("endgame"))
        {
            gameOverPanel.SetActive(true);
            isEnded = true;
            
        }
        else if (collision.gameObject.CompareTag("win"))
        {
            winPanel.SetActive(true);
            isEnded = true;
        }
    }
    void PauseGame()
    {
        if (isEnded)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
