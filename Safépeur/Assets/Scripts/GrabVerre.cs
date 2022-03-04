using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabVerre : MonoBehaviour
{
    public GameObject player;
    public bool VerreGrab = false;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if (VerreGrab == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1,
                player.transform.position.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D player)
    {

        VerreGrab = true;
    }
}
