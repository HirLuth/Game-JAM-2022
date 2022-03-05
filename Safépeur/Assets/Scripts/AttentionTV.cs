using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionTV : MonoBehaviour
{
    public SpriteRenderer sr;
    public TV tv;
    
    
    void Update()
    {
        if (tv.dontChange == false)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
