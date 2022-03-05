using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toilettes : MonoBehaviour
{
    public bool isAtRange;
    private void OnTriggerStay2D(Collider2D other)
    {
        isAtRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isAtRange = false;
    }
}
