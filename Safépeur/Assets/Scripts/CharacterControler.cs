using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Déplacements")] 
    public float speed;
    public bool canGoUp;
    private float direction;


    [Header("Echelle")] 
    public float vitesseEchelle;
    public float hautEchelle = 2.59f; // Altitude à laquelle s'arrête l'état échelle max
    public float basEchelle = -2.45f; // Altitude à laquelle s'arrête l'état échelle min
    private float directionVerticale;
    private bool surEchelle;
    public BoxCollider2D bc;
    

    [Header("Autres")] 
    public Rigidbody2D rb;
    public GameObject solPremierEtage;
    private KeyCode GoUp = KeyCode.UpArrow;
    private KeyCode GoDown = KeyCode.DownArrow;

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        if (surEchelle || canGoUp & (Input.GetKey(GoUp) || Input.GetKey(GoDown)))
        {
            Echelle();
        }
        else
        {
            MoveCharacter();
        }
    }
    
    void MoveCharacter()
    {
        rb.velocity = new Vector2(speed * direction, 0);
    }

    void Echelle()
    {
        // Pour activer l'état échelle à donf
        rb.gravityScale = 0;
        surEchelle = true;
        bc.isTrigger = true;
        
        directionVerticale = Input.GetAxisRaw("Vertical");

        
        if (directionVerticale < 0.1f && directionVerticale > -0.1f)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, vitesseEchelle * directionVerticale);
        }

        // Pour sortir de l'état échelle
        if (transform.position.y > hautEchelle || transform.position.y < basEchelle)
        {
            rb.gravityScale = 8;
            bc.isTrigger = false;
            surEchelle = false;
        }
    }
}
