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
    

    private void Update()
    {
        // Quand le perso est à portée
        if (canInteract == true)
        {
            sr.sprite = spritesListOutlined[gazinièreState];
        }
        
        // Quand le perso est trop loin 
        if (canInteract == false)
        {
            sr.sprite = spritesListNotOutlined[gazinièreState];
        }
    }

    public void DepartGaziniere(float timeToDo)
    {
        
        gazinièreOn = true;
        
        playerDistance = Mathf.Abs(player.transform.position.x - transform.position.x);
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
            em.GameOver();
            gazinièreOn = false;
        }
        if (playerDistance < 3)
        {
            canInteract = true;
            if (Input.GetKeyDown(Space))
            {
                gazinièreOn = false;
                timerGaziniere = 0;
                gazinièreState = 0;
            }
        }
        else
        {
            canInteract = false;
        }
        
    }
}
