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
    public AudioClip audioClip1;
    public AudioSource audioSource2;


    public void Ouverture()
    {
        audioSource1.PlayOneShot(audioClip1);
        ouverturePorte = true;
        timerPorte += Time.deltaTime;

        float mouvement = Input.GetAxisRaw("Horizontal");


        if (timerPorte >= tempsOuverture)
        {
            opens = true;
            audioSource2.Play();
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
