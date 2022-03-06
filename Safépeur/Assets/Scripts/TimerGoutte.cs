using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGoutte : MonoBehaviour
{
    public float tempsAnimation;
    public float timerGoutte;
    public GameObject goutteQuiBouge;
    void Update()
    {
        timerGoutte += Time.deltaTime;
        if (timerGoutte >= tempsAnimation)
        {
            goutteQuiBouge.transform.position = transform.position;
            timerGoutte = 0;
        }
    }
}
