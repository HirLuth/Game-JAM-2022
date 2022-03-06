using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazinièreActivation : MonoBehaviour
{
    public GameObject player;
    public float playerDistance;
    public int gazinièreState = 0;
    public KeyCode Space = KeyCode.Space;
    public float timePerStep;
    public float numberOfStates = 3;
    public float timerGaziniere = 0;
    public Event_Manager em;
    
    public bool gazinièreOn;
    public float timeToDo = 10;
    public bool canInteract;
    
    // Ca c'est les sprites
    public List<Sprite> spritesListNotOutlined;
    public List<Sprite> spritesListOutlined;
    public SpriteRenderer sr;

    public AudioSource audioSource1;
    private bool audioBool = true;

    private void Update()
    {
        if (gazinièreState > 5)
        {
            gazinièreState = 5;
        }
        
        // Quand le perso est à portée
        if (canInteract == true && gazinièreOn == true)
        {
            sr.sprite = spritesListOutlined[gazinièreState];
        }
        
        // Quand le perso est trop loin 
        if (canInteract == false || gazinièreOn == false)
        {
            sr.sprite = spritesListNotOutlined[gazinièreState];
        }

        if (gazinièreOn == true && audioBool == true)
        {
            audioSource1.Play();
            audioBool = false;
        }
        
        if (gazinièreOn == false )
        {
            audioSource1.Stop();
            audioBool = true;
        }

        
    }
    

    public void DepartGaziniere(float timeToDo)
    {
        gazinièreOn = true;
        
        timePerStep = timeToDo / numberOfStates;
        
        if (gazinièreState == 0)
        {
            gazinièreState = 1;
        }
        timerGaziniere += Time.deltaTime;
        if (timerGaziniere >= timePerStep)
        {
            gazinièreState += 1;
            timerGaziniere = 0;
        }

        if (gazinièreState == numberOfStates + 1)
        {
            em.GameOverFeu();
            gazinièreOn = false;
        }
        
        if (canInteract == true)
        {
            if (Input.GetKeyDown(Space))
            {
                gazinièreOn = false;
                timerGaziniere = 0;
                gazinièreState = 0;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
    }
}
