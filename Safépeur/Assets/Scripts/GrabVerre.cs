using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabVerre : MonoBehaviour
{
    public GameObject player;
    public GameObject zonePose;
    public bool VerreGrab = false;
    private float playerDistance;
    public KeyCode Space = KeyCode.Space;
    
    void Update()
    {
        playerDistance = Mathf.Abs(player.transform.position.x - zonePose.transform.position.x);
        if (VerreGrab == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1,
                player.transform.position.z);
        }

        if (VerreGrab == false)
        {
            transform.position = zonePose.transform.position; 
        }

        if (playerDistance < 3)
        {
            if (Input.GetKeyDown(Space) && VerreGrab == true)
            {
                
                VerreGrab = false;
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D player)
    {

        VerreGrab = true;
    }
}
