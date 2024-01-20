using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOver() {
        Debug.Log("Game over");
    }

    public void IncreaseScore() {
        score++;
    }

}
