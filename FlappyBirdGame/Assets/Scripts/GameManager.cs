using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    public Text scoreText;
    public Text highScoreText;
    public GameObject playButton;
    public GameObject gameOverText;
    private int score;

    private void Awake() {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
        Application.targetFrameRate = 60; // Set FPS
        Pause();
    }

    public void Play() {
        // Reset score
        score = 0;
        scoreText.text = score.ToString();

        // Tat UI
        playButton.SetActive(false);
        gameOverText.SetActive(false);

        // Bat dau chay game
        Time.timeScale = 1f;
        player.enabled = true;
        
        PipesMovement[] pipes = FindObjectsOfType<PipesMovement>(); // Co "s" cho "objects"

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f; // Freeze the game (Not update the time)
        player.enabled = false;
    }

    public void GameOver() {
        gameOverText.SetActive(true);
        playButton.SetActive(true);
        UpdateHighScore();

        Pause();
    }

    // Score functions

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore() {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High score: " + score.ToString();
        }
    }

    public void ResetHighScore() {
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("HighScore");
    }

}
