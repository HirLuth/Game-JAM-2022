using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TV : MonoBehaviour
{
    
    [Header("Paramètres")]
    public float limitTimerTV;
    public float limitTimerTV2;
    
    [Header("Autres")]
    public bool TVBugs;
    public float timerTV;
    private KeyCode interaction = KeyCode.Space;
    private bool illumine;

    public Sprite grésillement;
    public Sprite grésillement2;
    public Sprite mauvais1;
    public Sprite mauvais12;
    public Sprite mauvais2;
    public Sprite mauvais22;
    public Sprite mauvais3;
    public Sprite mauvais32;
    public Sprite bon;
    public Sprite bon2;
    public int spriteActuel = 4;
    private bool quitFirstChanel;
    public bool dontChange = true;
    private int retenue;

    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        // Si le perso est suffisamment proche pour actionner la TV
        if (illumine == true)
        {
            if (spriteActuel == 0)
            {
                spriteRenderer.sprite = grésillement2;
            }
            else if (spriteActuel == 1)
            {
                spriteRenderer.sprite = mauvais12;
            }
            else if (spriteActuel == 2)
            {
                spriteRenderer.sprite = mauvais22;
            }
            else if (spriteActuel == 3)
            {
                spriteRenderer.sprite = mauvais32;
            }
            else
            {
                spriteRenderer.sprite = bon2;
            }
        }
        
        // Si le perso est trop loin pour intégir ave la télé
        else
        {
            if (spriteActuel == 0)
            {
                spriteRenderer.sprite = grésillement;
            }
            else if (spriteActuel == 1)
            {
                spriteRenderer.sprite = mauvais1;
            }
            else if (spriteActuel == 2)
            {
                spriteRenderer.sprite = mauvais2;
            }
            else if (spriteActuel == 3)
            {
                spriteRenderer.sprite = mauvais3;
            }
            else
            {
                spriteRenderer.sprite = bon;
            }
        }
    }

    public void BugTV(float limitTimerTV, float limitTimerTV2)
    {
        TVBugs = true;
        dontChange = false;
        
        // Quand le perso appuie pour changer de chaîne
        if (Input.GetKeyDown(interaction))
        {
            retenue = spriteActuel;
            timerTV = 0;
            while (spriteActuel == retenue)
            {
                spriteActuel = Random.Range(1, 5);
            }
        }
        
        
        // Quand la chaine affichée est le grézillement
        if (spriteActuel == 0)
        {
            timerTV += Time.deltaTime;
            
            if (timerTV > limitTimerTV)
            {
                Debug.Log("Mort");
            }
        }
        
        // Quand c'est pas le grésillement
        else if (spriteActuel >= 0)
        {
            timerTV += Time.deltaTime;
            
            // Si c'est une des mauvaises chaînes
            if (spriteActuel < 4)
            {
                if (limitTimerTV2 < timerTV || dontChange == true)
                {
                    Debug.Log("Mort");
                }
            }

            // Si c'est la chaine des télétubbies
            if (spriteActuel == 4)
            {
                dontChange = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        illumine = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        illumine = false;
    }
}