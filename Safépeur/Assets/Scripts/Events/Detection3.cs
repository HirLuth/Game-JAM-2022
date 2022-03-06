using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection3 : MonoBehaviour
{
    public Fenêtre3 fenetre;
    public Event_Manager manager;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (fenetre.canDie == true)
        {
            manager.GameOver();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (fenetre.canDie == true)
        {
            manager.GameOver();
        }
    }
}
