using UnityEngine;
using System;
using UnityEngine.UI;


public class ObstaclesInteraction : MonoBehaviour
{   
    public AudioClip soundToPlay;

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
    bool ShielIsActivate = false;
    public AudioClip audioObstacle;
    public AudioClip audioPowerUp;
    public AudioClip audioCollectible;
    public AudioSource audioSource;
    public float soundVolume = 1.0f;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealthUI();
        CurrentLife = MaxLife;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // S'assure que le volume est pris en compte
        audioSource.volume = soundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        uiModificator.ChangeText(Score);
        UpdateHealthUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            
            if (audioObstacle != null)
            {
                audioSource.PlayOneShot(audioObstacle,soundVolume);
            }
            if(ShielIsActivate == true)
            {
                Shield.SetActive(false);
                ShielIsActivate = false;
            }
            else
            {
                CurrentLife--;
                UpdateHealthUI();
            }
            if (CurrentLife <= 0)
            {
                Application.Quit();
            }
            Debug.Log("Nombre de vie restante: " + CurrentLife);
            DestroyActor(other);
        }

        if(other.CompareTag("Shield"))
        {
            if (audioPowerUp != null)
            {
                audioSource.PlayOneShot(audioPowerUp,soundVolume);
            }
            Shield.SetActive(true);
            ShielIsActivate = true;
            Debug.Log("Nombre de vie restante: " + CurrentLife);
            DestroyActor(other);
        }
        if(other.CompareTag("Collectible"))
        {
            if (audioCollectible != null)
            {
                audioSource.PlayOneShot(audioCollectible,soundVolume);
            }
            CurrentScore = CurrentScore + ScoreValue;
            Score = CurrentScore;
            Debug.Log("Score actuel: " + Score);
        }

        if(other.CompareTag("Multiplicateur"))
        {
            if (audioPowerUp != null)
            {
                audioSource.PlayOneShot(audioPowerUp,soundVolume);
            }
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