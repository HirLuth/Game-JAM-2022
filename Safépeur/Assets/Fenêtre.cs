using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenêtre : MonoBehaviour
{
    public float timerFenêtre = 0f;
    public bool openingFenetre;
    
    public bool canDie;

    public SpriteRenderer spriteRenderer;
    public Sprite fenetreNormale;
    public Sprite fenetreFermée;
    public Sprite fenetreAttentionDanger;

    public void OuvertureFenetre(float rideauxFin, float yeuxFin)
    {
        openingFenetre = true;
        timerFenêtre += Time.deltaTime;

        if (timerFenêtre < rideauxFin)
        {
            spriteRenderer.sprite = fenetreFermée;
        }
        else
        {
            spriteRenderer.sprite = fenetreAttentionDanger;
            canDie = true;
        }

        if (timerFenêtre > yeuxFin)
        {
            canDie = false;
            spriteRenderer.sprite = fenetreNormale;
            timerFenêtre = 0;
            openingFenetre = false;
        }
    }
}
