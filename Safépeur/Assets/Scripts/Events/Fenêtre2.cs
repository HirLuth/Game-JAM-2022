using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Fenêtre2 : MonoBehaviour
{
    public float timerFenêtre = 0f;
    public bool openingFenetre;
    public Event_Manager manager;

    public bool canDie;
    public Vector4 retenue;

    public SpriteRenderer spriteRenderer;
    public Sprite fenetreNormale;
    public Sprite fenetreFermée;
    public Sprite fenetreAttentionDanger;
    public Light2D light;

    public AudioSource audioSource1;
    public bool audioBool1 = true;
    public bool audioBool2 = true;
    public bool eventManager2;

    private void Update()
    {
        if (eventManager2)
        {
            OuvertureFenetre(3f, 7.5f);
        }
    }

    public void OuvertureFenetre(float rideauxFin, float yeuxFin)
    {
        openingFenetre = true;
        
        timerFenêtre += Time.deltaTime;
        

        // Ca se ferme
        if (timerFenêtre < rideauxFin)
        {
            if (audioBool1 == true)
            {
                audioSource1.Play();
                audioBool1 = false;
            }
            spriteRenderer.sprite = fenetreFermée;
            light.intensity = 0;
        }
        
        // La c'est le danger
        else
        {
            if (audioBool2 == true)
            {
                retenue = light.color;
                audioSource1.Play();
                audioBool2 = false;
            }
            spriteRenderer.sprite = fenetreAttentionDanger;
            light.intensity = 0.01f;
            light.color = new Vector4(207,38,44, 50);
            
            Debug.Log(canDie);

            if (canDie)
            {
                manager.GameOver();
            }
        }

        // Retour à la normale
        if (timerFenêtre > yeuxFin)
        {
            audioBool1 = true;
            audioBool2 = true;
            light.color = retenue;
            light.intensity = 1;
            Debug.Log(light.intensity);
            canDie = false;
            spriteRenderer.sprite = fenetreNormale;
            
            timerFenêtre = 0;
            eventManager2 = false;
            

            openingFenetre = false;
        }
    }
}
