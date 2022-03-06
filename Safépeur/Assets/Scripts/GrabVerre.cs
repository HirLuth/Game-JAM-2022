using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabVerre : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject player;
    public GameObject zonePose;
    public GameObject toilettes;
    
    
    [Header("Autres")]
    public bool VerreGrab;   // Si le perso tient le verre
    public KeyCode Space = KeyCode.Space;
    public int VerreFilling = 8;
    public float timerVerreFilling = 0;
    public FlacQuiTue flaque;
    public toilettes toilettesProg;
    public Event_Manager manager;
    
    
    [Header("Sprites")]
    public SpriteRenderer spToilettes;
    public SpriteRenderer spGouttes;
    public SpriteRenderer spVerre;
    public List<Sprite> spritesOutlined;
    public List<Sprite> spritesNotOutlined;
    public Sprite toilettesSpriteSet;
    public Sprite toilettesSpriteUnset;
    public Sprite gouttesSpriteSet;
    public Sprite gouttesSpriteUnset;

    public AudioSource audioSource1;
    private bool audioBool = true;


    void Update()
    {
        timerVerreFilling += Time.deltaTime;
        
        
        if (VerreFilling >= 7)
        {
            VerreFilling = 7;
            manager.GameOver();
        }

        if (timerVerreFilling > 5 && VerreGrab == false)
        {
            VerreFilling += 1;
            timerVerreFilling = 0;
        }

        if (VerreGrab == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1,
                player.transform.position.z);
            timerVerreFilling = 0;
        }

        if (VerreGrab == false)
        {
            transform.position = zonePose.transform.position;
        }

        // Si le perso peut prendre le verre
        if (flaque.isAtRange == true)
        {
            // On illumine le contour
            spGouttes.sprite = gouttesSpriteSet; 
            if (Input.GetKeyDown(Space) )
            {
                if(VerreGrab == true)
                {
                    VerreGrab = false;
                }
                else
                {
                    VerreGrab = true;
                }
            }
        }
        else
        {
            spGouttes.sprite = gouttesSpriteUnset;
        }
    
        if (toilettesProg.isAtRange) 
        {
            spToilettes.sprite = toilettesSpriteSet; 
            if (Input.GetKeyDown(Space) )
            {
                if(VerreGrab == true)
                {
                    if (audioBool == true)
                    {
                        audioSource1.Play();
                        audioBool = false;
                    }
                    VerreFilling = 0;
                    timerVerreFilling = 0;
                }
            }
        }
        else
        {
            audioBool = true;
            spToilettes.sprite = toilettesSpriteUnset;
        }

        if (flaque.isAtRange == true && VerreGrab == false)
        {
            spVerre.sprite = spritesOutlined[VerreFilling];
        }
        else
        {
            spVerre.sprite = spritesNotOutlined[VerreFilling];
        }

    }
}
