using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event_Manager : MonoBehaviour
{ 
    public float TimerDifficulty;

  [Header("(Attention)Dangers")] 
  public Porte porte;
  public TV TV;
  public Fenêtre fenetre;
  public Fenêtre2 fenetre2;
  public Fenêtre3 fenetre3;
  public GazinièreActivation gazinière;

  [Header("Prochain danger")]
  public float prochainDanger;
  public float timerProchainDanger;
  private float difficulté = 1;


  [Header("DifficultéTV")] 
  public float TVLimite1 = 10;
  public float TVLimite11 = 9;
  public float TVLimite111 = 8;
  public float TVLimite2 = 1.25f;
  public float TVLimite22 = 1;
  public float TVLimite222 = 0.75f;

  [Header("DifficultéFenêtre")] 
  public float dureeFenetre1 = 3f;
  public float dureeFenetre2 = 9f;
  public int numeroFenetre;

  [Header("difficultéGazinière")] 
  public float gaziniereDuree = 15f;


  [Header("UI")] 
  public TextMeshProUGUI textGameOver;
  public GameObject UIGameOver;
  public GameObject Screamer;
  private float timerScreamer;
  public int timerMaxScreamer;
  public GameObject timerTemps;


  [Header("gameOver")] 
  public cameraShake cameraShake;
  public GameObject screamer;
  private bool screaming;



  void Start()
    {
        Event_Fuite();
        UIGameOver.SetActive(false);
        Time.timeScale = 1;
        Screamer.SetActive(false);
    }


    void Update()
    {
        if (screaming)
        {
            GameOver();
        }
        
        TimerDifficulty += Time.deltaTime;

        // On fait évoluer la difficulté avec le temps 
        if (TimerDifficulty > 60)
        {
            difficulté = 1.1f;
        }
        else if (TimerDifficulty > 120)
        {
            difficulté = 1.2f;
        }

        
        // Si l'évènement de la porte est en cours
        if (porte.ouverturePorte)
        {
            porte.Ouverture();
        }

        if (gazinière.gazinièreOn == true)
        {
            gazinière.DepartGaziniere(gaziniereDuree);
        }

        if (fenetre.openingFenetre || fenetre2.openingFenetre || fenetre3.openingFenetre)
        {
            if (numeroFenetre == 1)
            {
                fenetre.OuvertureFenetre(dureeFenetre1, dureeFenetre2);
            }
            else if (numeroFenetre == 2)
            {
                fenetre2.OuvertureFenetre2(dureeFenetre1, dureeFenetre2);
            }
            else
            {
                fenetre3.OuvertureFenetre3(dureeFenetre1, dureeFenetre2);
            }
        }
        

        // Plus la difficulté est haute, plus le timer va vite et donc plus les dangers arrivent rapidement
        if (timerProchainDanger < prochainDanger)
        {
            timerProchainDanger += Time.deltaTime * difficulté;
        }
        else
        {
            ChoixEvent();
        }
    }

    void ChoixEvent()
    {
        timerProchainDanger = 0;

        float randomNumber = Random.Range(1,80);
        
        if (randomNumber < 20)
        {
            porte.Ouverture();
        }
        else if (randomNumber < 40)
        {
            numeroFenetre = Random.Range(1, 4);
            if (numeroFenetre == 1)
            {
                fenetre.OuvertureFenetre(dureeFenetre1, dureeFenetre2);
            }
            else if (numeroFenetre == 2)
            {
                fenetre2.OuvertureFenetre2(dureeFenetre1, dureeFenetre2);
            }
            else
            {
                fenetre3.OuvertureFenetre3(dureeFenetre1, dureeFenetre2);
            }
        }
        else if (randomNumber < 60)
        {
            gazinière.DepartGaziniere(gaziniereDuree);
        }
        else
        {
            TV.spriteActuel = 0;
            TV.timerTV = 0;
        }
    }


    public void GameOver()
    {
        timerScreamer += Time.deltaTime;

        if (timerScreamer < 2)
        {
            screamer.SetActive(true);
            StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
        }
        else
        {
            timerTemps.SetActive(false);
            Screamer.SetActive(true);
            Time.timeScale = 0;
            textGameOver.text = "You survived " + Mathf.Round(TimerDifficulty) + " seconds";
            UIGameOver.SetActive(true);
        }
    }

    
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    void Event_Porte()
    {
        
    }
    
    void Event_Fenêtre()
    {
        
    }
    
    void Event_Feu()
    {
        
    }
    
    void Event_Télé()
    {
        
    }
    
    
    void Event_Fuite()
    {
        
    }
}
