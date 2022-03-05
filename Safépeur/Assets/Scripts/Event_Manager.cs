using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{

   // public bool Event_Fuite;      //1
    //public bool Event_Porte;     //2
    //public bool Event_Fenêtre;  //3
    //  public bool Event_Feu;   //4
  //  public bool Event_Télé;   //5
  public float TimerDifficulty;

  [Header("(Attention)Dangers")] 
  public Porte porte;
  public TV TV;

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
  
  
  
  
    void Start()
    {
        //prochainDanger = Random.Range(1, 100);
        Event_Fuite();
    }


    void Update()
    {
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
        
        // Si l'évènement de la TV est en cours (toujours actif)
        if (TV.TVBugs)
        {
            TV.BugTV(TVLimite1, TVLimite2);
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
        Debug.Log("Oui");
        
        float randomNumber = Random.Range(1,100);
        
        if (randomNumber < -20)
        {
            porte.Ouverture();
        }
        else if (randomNumber < -40)
        {
            Event_Fenêtre();
        }
        else if (randomNumber < -80)
        {
            Event_Feu();
        }
        else
        {
            TV.spriteActuel = 0;
            TV.timerTV = 0;
            TV.BugTV(TVLimite1, TVLimite2);
        }
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
