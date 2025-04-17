using UnityEngine;

public class EndGame : MonoBehaviour
{
    
    
    public ObstaclesInteraction obstaclesInteraction;
    public EndGameUi endUI;


    void FinishRace()
    {
        endUI.ShowEndScreen(obstaclesInteraction.Score, obstaclesInteraction.CurrentLife);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FinishRace();
        }
        else
        {
            return;
        }
    }


}
