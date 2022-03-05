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



    public void Ouverture()
    {
        ouverturePorte = true;
        
        timerPorte += Time.deltaTime;

        float mouvement = Input.GetAxisRaw("Horizontal");


        if (timerPorte >= tempsOuverture)
        {
            opens = true;
        }
        
        if (timerPorte >= tempsOuverture && (mouvement > 0.01f || mouvement < -0.01f))
        {
            manager.GameOver();
        }
        
        else if (timerPorte >= (tempsOuverture + 2.5f))
        {
            opens = false;
            ouverturePorte = false;
            retenueFaite = false;
            timerPorte = 0;
        }
        
        anim.SetBool("PorteOuverte", ouverturePorte);

    }
}
