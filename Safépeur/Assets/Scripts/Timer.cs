using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 0;
    public TextMeshProUGUI timerText;
    
    
    void Update()
    {
        if (Time.timeScale != 0)
        {
            timeValue += Time.deltaTime;
            DisplayTime(timeValue);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float secondes = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
    
}


