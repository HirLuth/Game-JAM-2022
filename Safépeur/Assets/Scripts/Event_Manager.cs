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

  [Header("Dangers")] 
  public Porte porte;

  [Header("Prochain danger")]
  public float prochainDanger;
  public float timerProchainDanger;
  private float difficulté = 1;
  
  
  
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

        if (porte.ouverturePorte)
        {
            porte.Ouverture();
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
        
        if (randomNumber < 200)
        {
            porte.Ouverture();
        }
        else if (randomNumber < 40)
        {
            Event_Fenêtre();
        }
        else if (randomNumber < 80)
        {
            Event_Feu();
        }
        else
        {
            Event_Télé();
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
