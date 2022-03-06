using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection2 : MonoBehaviour
{
    public Fenêtre2 fenetre;
    public Event_Manager manager;

    private void OnTriggerExit2D(Collider2D other)
    {
        fenetre.canDie = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        fenetre.canDie = true;
    }
}
