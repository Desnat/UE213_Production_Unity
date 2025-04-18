using UnityEngine;
using System;
using UnityEngine.UI;


public class ObstaclesInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject vehicle;
    public Collider selfCollider;
    public UiModificator uiModificator;
    [Header("Life Value")]
    public Image[] heartImages;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    public int MaxLife = 3;
    [NonSerialized]
    public int CurrentLife = 3;
    public GameObject Shield;

    [Header("Score Value")]
    public int ScoreValue;
    public int Multiplicateur;
    public Int32 MultiplicateurTime;

    public GameObject Multi;
    int CurrentScore = 0;
    [NonSerialized]
    public int Score;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealthUI();
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
            if(Shield == true)
            {
                Shield.SetActive(false);
            }
            else
            {
                UpdateHealthUI();
            }
            if (CurrentLife <= 0)
            {
                Application.Quit();
            }
        }

        if(other.CompareTag("Shield"))
        {
            CurrentLife++;
            Shield.SetActive(true);
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
            Multi.SetActive(true);
            DestroyActor(other);
        }

    }
    public void NoMultiplicator()
    {
        ScoreValue = ScoreValue/Multiplicateur;
        Debug.Log("Score divisé par "+ Multiplicateur);
        Multi.SetActive(false);
    }
    
    public void DestroyActor(Collider other) 
    {
        Destroy(other.gameObject);
    }
    private void UpdateHealthUI()
    {
        // Boucle à travers chaque cœur pour afficher son état
        for (int i = 0; i < MaxLife; i++)
        {
            if (i < CurrentLife)
            {
                heartImages[i].sprite = fullHeartSprite; // Cœur plein
            }
            else
            {
                heartImages[i].sprite = emptyHeartSprite; // Cœur assombri
            }
        }
    }
}