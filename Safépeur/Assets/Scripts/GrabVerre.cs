using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabVerre : MonoBehaviour
{
    public GameObject player;
    public GameObject zonePose;
    public GameObject toilettes;
    public SpriteRenderer spToilettes;
    public SpriteRenderer spGouttes;
    public Sprite toilettesSpriteSet;
    public Sprite toilettesSpriteUnset;
    public Sprite gouttesSpriteSet;
    public Sprite gouttesSpriteUnset;
    public bool VerreGrab;
    private float playerDistanceZone;
    private float playerDistanceToilettes;
    public KeyCode Space = KeyCode.Space;
    public int VerreFilling = 8;
    public float timerVerreFilling = 0;
    
    void Update()
    {
        playerDistanceZone = Mathf.Abs(player.transform.position.x - zonePose.transform.position.x);
        playerDistanceToilettes = Mathf.Abs(player.transform.position.x - toilettes.transform.position.x);
        timerVerreFilling += Time.deltaTime;
        
    
        
        if (VerreFilling >= 8)
        {
            VerreFilling = 8;
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

        if (playerDistanceZone < 3) 
        {
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
    
        if (playerDistanceToilettes < 3) 
        {
            spToilettes.sprite = toilettesSpriteSet; 
            if (Input.GetKeyDown(Space) )
            {
                if(VerreGrab == true)
                {
                    VerreFilling = 0;
                    timerVerreFilling = 0;
                }
            }
        }
        else
        {
            spToilettes.sprite = toilettesSpriteUnset;
        }
        
        
    }
}
