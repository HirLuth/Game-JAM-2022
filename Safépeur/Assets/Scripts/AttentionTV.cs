using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionTV : MonoBehaviour
{
    public SpriteRenderer sr;
    public TV tv;
    
    
    void Update()
    {
        if (tv.spriteActuel != 4)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
