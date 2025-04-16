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
    int Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    }



}
