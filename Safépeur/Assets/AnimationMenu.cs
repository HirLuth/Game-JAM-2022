using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenu : MonoBehaviour
{

    public UIMenu uiScript;
    public Animation anim;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uiScript.QuitActif == true)
        {
            anim.Play("AnimMenu");
        }
    }
}
