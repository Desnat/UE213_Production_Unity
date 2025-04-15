using UnityEngine;
using System;

public class ObstaclesInteraction : MonoBehaviour
{
    public GameObject vehicle;
    public Collider selfCollider;
    public float CurrentScore = 0;
    public float ScoreValue;
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
        float Score = CurrentScore;
        if (other.CompareTag("Player"))
        {
            Score = CurrentScore + ScoreValue;
        }
    }

}
