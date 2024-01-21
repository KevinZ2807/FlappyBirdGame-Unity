using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOverText;
    private int score;

    private void Awake() {
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

        Pause();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

}
