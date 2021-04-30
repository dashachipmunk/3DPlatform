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
    Rigidbody ballRigidBody;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private AudioSource audioSource;
    private SoundManager soundManager;
    public AudioClip audioLostGame;
    public AudioClip audioWin;
    public enum BallState
    {
        FALL,
        JUMP
    }

    private void Awake()
    {
        singleton = this;
        ballRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ballState = BallState.JUMP;
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        print(ballRigidBody.velocity.magnitude);
        if (ballRigidBody.velocity.magnitude > maxSpeed)
        {
            ballRigidBody.velocity = ballRigidBody.velocity.normalized * maxSpeed;
        }
        scoreText.text = score.ToString();
        PauseGame();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        if (collision.gameObject.CompareTag("endgame"))
        {
            soundManager.PlaySound(audioLostGame);
            gameOverPanel.SetActive(true);
            isEnded = true;
        }
        else if (collision.gameObject.CompareTag("win"))
        {
            soundManager.PlaySound(audioWin);
            winPanel.SetActive(true);
            isEnded = true;
        }
    }

    private void PauseGame()
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
