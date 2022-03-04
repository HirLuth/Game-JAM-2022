using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echelle : MonoBehaviour
{
    public CharacterControler characterControler;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        characterControler.canGoUp = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        characterControler.canGoUp = false;
    }
}
