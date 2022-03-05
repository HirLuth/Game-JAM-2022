using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Fenêtre fenetre;
    public Event_Manager manager;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (fenetre.canDie == true)
        {
            manager.GameOver();
        }
    }
}
