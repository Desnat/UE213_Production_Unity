using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiModificator : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI VieText;
    //ObstaclesInteraction obstaclesInteraction;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText(int Score, int CurrentLife)
    {
        ScoreText.text = "Score : " + Score ;
        VieText.text = "Vie : " + CurrentLife;
    }
}
