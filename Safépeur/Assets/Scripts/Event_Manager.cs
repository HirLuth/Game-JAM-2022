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
  public float prochainDangerBad;
  public float prochainDangerMin = 7;
  public float prochainDangerBadMin = 2;
  public float prochainDangerArray = 3;
  public float prochainDangerBadArray = 5;
  public float timerProchainDanger;
  public float timerProchainDangerBad = 0;
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
  public float dureeFenetre2 = 7.5f;
  public int numeroFenetre = 1;
  public int secondNumeroFenetre = 2;
  public float retenue2;

  
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
  public GameObject screamerTV;
  public GameObject sceamerFire;
  public GameObject screamerVerre;
  private bool screaming;
  public GameObject lights;


  [Header("pourcentage")] 
  public float pourcentageFenêtre = 70;
  public float pourcentagePorte = 30;
  public float pourcentageGazinière = 60;
  public float pourcentageTV;
  
  



  void Start()
  {
        Time.timeScale = 1;
        Event_Fuite();
        UIGameOver.SetActive(false);
        Screamer.SetActive(false);
        prochainDanger = Random.Range(prochainDangerMin, prochainDangerMin + prochainDangerArray);
        prochainDangerBad = Random.Range(prochainDangerBadMin, prochainDangerBadMin + prochainDangerBadArray);

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
            difficulté = 1.2f;
        }
        else if (TimerDifficulty > 120)
        {
            difficulté = 1.4f;
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


        // Plus la difficulté est haute, plus le timer va vite et donc plus les dangers arrivent rapidement
        if (timerProchainDanger < prochainDanger)
        {
            timerProchainDanger += Time.deltaTime * difficulté;
        }
        else
        {
            ChoixEvent();
        }

        if (timerProchainDangerBad < prochainDangerBad)
        {
            timerProchainDangerBad += Time.deltaTime * difficulté;
        }
        else
        {
            ChoixBadEvent();
        }
    }

    void ChoixEvent()
    {
        timerProchainDanger = 0;
        prochainDanger = Random.Range(prochainDangerMin, prochainDangerMin + prochainDangerArray);
        float randomNumber = Random.Range(1,101);
        
        if (randomNumber < pourcentageGazinière)
        {
            gazinière.DepartGaziniere(gaziniereDuree);
        }
        else
        {
            TV.spriteActuel = 0;
        }
    }

    void ChoixBadEvent()
    {
        timerProchainDangerBad = 0;
        prochainDangerBad = Random.Range(prochainDangerBadMin, prochainDangerBadMin + prochainDangerBadArray);

        float randomNumber = Random.Range(1,101);
        
        if (randomNumber < pourcentagePorte)
        {
            porte.Ouverture();
        }
        else
        {
            while (retenue2 == numeroFenetre)
            {
                numeroFenetre = Random.Range(1, 4);
            }
            retenue2 = numeroFenetre;
            
            
            if (numeroFenetre == 1)
            {
                fenetre.eventManager = true;
            }
            else if (numeroFenetre == 2)
            {
                fenetre2.eventManager2 = true;
            }
            else
            {
                fenetre3.eventManager3 = true;
            }
        }
        
    }
    
    public void GameOverVerre()
    {
        timerScreamer += Time.deltaTime;
        lights.SetActive(false);

        if (timerScreamer < 2 && screaming == false)
        {
            screaming = true;
            screamerVerre.SetActive(true);
            StartCoroutine(cameraShake.Shake(2f, 0.3f));
        }
        else if (timerScreamer >= 2)
        {
            timerTemps.SetActive(false);
            Screamer.SetActive(true);
            Time.timeScale = 0;
            textGameOver.text = "You survived " + Mathf.Round(TimerDifficulty) + " seconds";
            UIGameOver.SetActive(true);
        }
    }


    public void GameOverFeu()
    {
        timerScreamer += Time.deltaTime;
        lights.SetActive(false);

        if (timerScreamer < 2 && screaming == false)
        {
            screaming = true;
            sceamerFire.SetActive(true);
            StartCoroutine(cameraShake.Shake(2f, 0.3f));
        }
        else if (timerScreamer >= 2)
        {
            timerTemps.SetActive(false);
            Screamer.SetActive(true);
            Time.timeScale = 0;
            textGameOver.text = "You survived " + Mathf.Round(TimerDifficulty) + " seconds";
            UIGameOver.SetActive(true);
        }
    }

    
    public void GameOverTV()
    {
        timerScreamer += Time.deltaTime;
        lights.SetActive(false);

        if (timerScreamer < 2 && screaming == false)
        {
            screaming = true;
            screamerTV.SetActive(true);
            StartCoroutine(cameraShake.Shake(2f, 0.3f));
        }
        else if (timerScreamer >= 2)
        {
            timerTemps.SetActive(false);
            Screamer.SetActive(true);
            Time.timeScale = 0;
            textGameOver.text = "You survived " + Mathf.Round(TimerDifficulty) + " seconds";
            UIGameOver.SetActive(true);
        }
    }

    public void GameOver()
    {
        timerScreamer += Time.deltaTime;
        lights.SetActive(false);

        if (timerScreamer < 2 && screaming == false)
        {
            screaming = true;
            screamer.SetActive(true);
            StartCoroutine(cameraShake.Shake(2f, 0.3f));
        }
        else if (timerScreamer >= 2)
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
    
    void Event_Fuite()
    {
        
    }
}
