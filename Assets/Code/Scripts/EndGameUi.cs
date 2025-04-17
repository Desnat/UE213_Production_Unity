using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameUi : MonoBehaviour
{
    public GameObject endScreenPanel;
    public TMP_Text finalScoreText;
    public TMP_Text remainingLivesText;
    
    
    
    public void ShowEndScreen(int finalScore, int livesLeft)
    {
        finalScoreText.text = "Score final : " + finalScore;
        remainingLivesText.text = "Vies restantes : " + livesLeft;
        endScreenPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
