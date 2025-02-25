using UnityEngine;
using TMPro; 

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public GameManager gameManager;

    void Update()
    {
        if (scoreText != null && gameManager != null)
        {
            scoreText.text = "Score: " + gameManager.score; 
        }
    }
}