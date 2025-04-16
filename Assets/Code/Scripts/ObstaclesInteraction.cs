using UnityEngine;
using System;

public class ObstaclesInteraction : MonoBehaviour
{
    public GameObject vehicle;
    public Collider selfCollider;
    public int CurrentLife = 3;
    public int MaxLife = 3;
    public int CurrentScore = 0;
    public int ScoreValue;
    public int Score;
    public UiModificator uiModificator;
    public int Multiplicateur;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uiModificator.ChangeText(Score,CurrentLife);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            CurrentLife--;
            Debug.Log("Nombre de vie restante: " + CurrentLife);
            if (CurrentLife <= 0)
            {
                Application.Quit();
            }
        }

        if (other.CompareTag("Shield"))
        {
            CurrentLife++;
            Debug.Log("Nombre de vie restante: " + CurrentLife);
        }
        if(other.CompareTag("Collectible"))
        {
            CurrentScore = CurrentScore + ScoreValue;
            Score = CurrentScore;
            Debug.Log("Score actuel: " + Score);
        }

        if(other.CompareTag("Multiplicateur"))
        {
            ScoreValue = ScoreValue * Multiplicateur;
            Debug.Log("Score multiplié par "+ Multiplicateur);
            Invoke("NoMultiplicator", 10);
        }

    }
    public void NoMultiplicator()
    {
        ScoreValue = ScoreValue/Multiplicateur;
        Debug.Log("Score divisé par "+ Multiplicateur);
    }
}
