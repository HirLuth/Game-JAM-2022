using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Fenêtre : MonoBehaviour
{
    public float timerFenêtre = 0f;
    public bool openingFenetre;

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

    public void Start()
    {
        retenue = light.color;
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
                audioSource1.Play();
                audioBool2 = false;
            }
            spriteRenderer.sprite = fenetreAttentionDanger;
            canDie = true;
            light.intensity = 0.01f;
            light.color = new Vector4(207,38,44, 50);
        }

        // Retour à la normale
        if (timerFenêtre > yeuxFin)
        {
            audioBool1 = true;
            audioBool2 = true;
            light.color = retenue;
            light.intensity = 1;
            canDie = false;
            spriteRenderer.sprite = fenetreNormale;
            
            timerFenêtre = 0;
            

            openingFenetre = false;
        }
    }
}
