using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlacQuiTue : MonoBehaviour
{
    public Event_Manager manager;
    public GrabVerre grabVerre;
    public float timerFlacFilling = 0;
    public int flacState = 0;
    public float timeToFill;
    public float timePerStep;
    public float numberOfStates = 5;
    public bool isAtRange;

    void Update()
    {
        if (grabVerre.VerreGrab == true)
        {
            timePerStep = timeToFill / numberOfStates;
            timerFlacFilling += Time.deltaTime;
            if (timerFlacFilling >= timePerStep)
            {
                flacState += 1;
                timerFlacFilling = 0;
            }

            if (flacState >= numberOfStates)
            {
                manager.GameOver();
                
            }
        }
        else
        {
            flacState = 0;
            timerFlacFilling = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        isAtRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isAtRange = false;
    }
}
