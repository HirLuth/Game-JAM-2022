using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Fenêtre fenetre;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (fenetre.canDie == true)
        {
            Debug.Log("La Mooooort");
        }
    }
}
