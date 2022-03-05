using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionGaziniere : MonoBehaviour
{
    public SpriteRenderer sr;
    public GazinièreActivation gazinièreActivation;
    
    
    void Update()
    {
        if (gazinièreActivation.gazinièreOn == true)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
