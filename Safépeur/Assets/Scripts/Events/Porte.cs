using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public Animator anim;
    public Event_Manager manager;
    

    public bool ouverturePorte;
    public float tempsOuverture;
    public float timerPorte = 0;
    public bool opens;
    private Vector3 retenue;
    private bool retenueFaite;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private bool stopSon;


    public void Ouverture()
    {
        ouverturePorte = true;
        
        if (ouverturePorte == true && stopSon == false)
        {
            stopSon = true;
            Debug.Log("son");
            audioSource1.Play();
        }
        
        timerPorte += Time.deltaTime;

        float mouvement = Input.GetAxisRaw("Horizontal");
        float mouvementVertical = Input.GetAxisRaw("Vertical");


        if (timerPorte >= tempsOuverture)
        {
            opens = true;
        }
        
        if (timerPorte >= tempsOuverture && (mouvement > 0.01f || mouvement < -0.01f || mouvementVertical > 0.01f || mouvementVertical < -0.01))
        {
            manager.GameOver();
        }
        
        else if (timerPorte >= (tempsOuverture + 2.5f))
        {
            stopSon = false;
            opens = false;
            ouverturePorte = false;
            retenueFaite = false;
            timerPorte = 0;
        }
        
        anim.SetBool("PorteOuverte", ouverturePorte);

        if (opens == false)
        {
            audioSource2.Play();
        }

    }
}
