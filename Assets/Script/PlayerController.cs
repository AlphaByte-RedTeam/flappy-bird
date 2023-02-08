using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public GameObject loseScreenUI;
    public int score;
    public int highScore;
    public Text scoreUI;
    public Text highScoreUI;
    string HIGH_SCORE = "HIGHSCORE";

    // Reference object RigidBody2D
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump() {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyUp("space"))
        {
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PlayerLose() {
        AudioManager.singleton.PlaySound(1);
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE, highScore);
        }
        highScoreUI.text = "High Score: " + highScore.ToString();
        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    void AddScore() {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("obstacle"))
            PlayerLose();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("score"))
            AddScore();
    }
}
