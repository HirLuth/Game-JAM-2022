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
  
  
    void Start()
    {
        Event_Fuite();
    }


    void Update()
    {
        TimerDifficulty += Time.deltaTime;
        ChoixEvent();
    }

    void ChoixEvent()
    {
        // Coroutine ??? tous les 20 secondes - TimerDifficulty
        float randomNumber = Random.Range(1,100);
        
        if (randomNumber < 20)
        {
            Event_Porte();
        }
        if (randomNumber > 20 && randomNumber < 40)
        {
            Event_Fenêtre();
        }
        if (randomNumber > 60 && randomNumber < 80)
        {
            Event_Feu();
        }
        if (randomNumber > 80)
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
