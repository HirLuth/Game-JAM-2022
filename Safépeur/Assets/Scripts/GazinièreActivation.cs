using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazinièreActivation : MonoBehaviour
{
    public GameObject player;
    public float playerDistance;
    public int gazinièreState = 5;
    public KeyCode Space = KeyCode.Space;
    public float timePerStep;
    public float numberOfStates = 5;
    public float timerGaziniere = 0;
    public bool gazinièreOn;
    public float timeToDo = 10;

    private void Update()
    {
        if (gazinièreOn == true)
        { 
            DepartGaziniere(timeToDo);
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

        if (gazinièreState == 5)
        {
            Debug.Log("tu es mort");
        }
        if (playerDistance < 3)
        {
            if (Input.GetKeyDown(Space))
            {
                gazinièreOn = false;
                timerGaziniere = 0;
                gazinièreState = 0;
            }
        }
        
    }
}
