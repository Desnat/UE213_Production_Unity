using UnityEngine;
using System;

public class ObstaclesInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject vehicle;
    public Collider selfCollider;
    public UiModificator uiModificator;
    [Header("Life Value")]
    public int MaxLife = 3;
    int CurrentLife = 3;
    [Header("Score Value")]
    public int ScoreValue;
    public int Multiplicateur;
    public Int32 MultiplicateurTime;
    int CurrentScore = 0;
    int Score;
    

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
            DestroyActor(other);
            if (CurrentLife <= 0)
            {
                Application.Quit();
            }
        }

        if(other.CompareTag("Shield"))
        {
            CurrentLife++;
            Debug.Log("Nombre de vie restante: " + CurrentLife);
            DestroyActor(other);
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
            Invoke("NoMultiplicator", MultiplicateurTime);
            DestroyActor(other);
        }

    }
    public void NoMultiplicator()
    {
        ScoreValue = ScoreValue/Multiplicateur;
        Debug.Log("Score divisé par "+ Multiplicateur);
    }
    
    public void DestroyActor(Collider other) 
    {
        Destroy(other.gameObject);
    }
}