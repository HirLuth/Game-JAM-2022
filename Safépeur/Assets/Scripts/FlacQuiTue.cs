using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlacQuiTue : MonoBehaviour
{
    public GrabVerre grabVerre;
    public float timerFlacFilling = 0;
    public int flacState = 0;
    public float timeToFill;
    public float timePerStep;
    public float numberOfStates = 5;

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
                Debug.Log("Tu es mort");
                
            }
        }
        else
        {
            flacState = 0;
            timerFlacFilling = 0;
        }
    }
}
