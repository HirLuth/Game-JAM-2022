using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoutteQuiCoule : MonoBehaviour
{
    public float speed = 2;
    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, transform.position + Vector3.down, speed * Time.deltaTime);
    }
}
