using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attentionVerre : MonoBehaviour
{
    public SpriteRenderer sr;
    public FlacQuiTue flaque;
    public GrabVerre verre;
    
    
    void Update()
    {
        if (verre.VerreGrab)
        {
            if (flaque.flacState >= 3)
            {
                sr.enabled = true;
            }
            else
            {
                sr.enabled = false;
            }
        }
        else
        {
            if (verre.VerreFilling >= 5)
            {
                sr.enabled = true;
            }
            else
            {
                sr.enabled = false;
            }
        }
    }
}
