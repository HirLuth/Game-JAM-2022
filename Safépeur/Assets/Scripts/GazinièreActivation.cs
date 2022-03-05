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
    public bool gazinièreOn;
    public float timeToDo = 10;
    public bool canInteract;
    public List<Sprite> spritesListNotOutlined;
    public List<Sprite> spritesListOutlined;
    public SpriteRenderer sr;
    

    private void Update()
    {
        if (canInteract == true)
        {
            sr.sprite = spritesListOutlined[gazinièreState];
        }
        if (canInteract == false)
        {
            sr.sprite = spritesListNotOutlined[gazinièreState];
        }
        if (gazinièreOn == true)
        { 
            DepartGaziniere(timeToDo);
        }
        else
        {
            canInteract = false;
        }
    }

    public void DepartGaziniere(float timeToDo)
    {
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

        if (gazinièreState == numberOfStates)
        {
            Debug.Log("tu es mort");
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
