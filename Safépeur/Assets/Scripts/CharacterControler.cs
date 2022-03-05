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
    public bool IsWalking2;
    public bool IsClimbing2;
    public Animator anim;
    public SpriteRenderer playerSP;
    public Sprite spriteClimb1;
    public Animation animStop;

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

        if (rb.velocity.x != 0)
        {
            IsWalking2 = true;
        }
        else
        {
            IsWalking2 = false;   
        }
        anim.SetBool("IsWalking",IsWalking2);
        anim.SetBool("IsClimbing",IsClimbing2);

        if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
            
        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
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
            IsClimbing2 = false;
        }
        else
        {
            rb.velocity = new Vector2(0, vitesseEchelle * directionVerticale);
            IsClimbing2 = true;
        }

        // Pour sortir de l'état échelle
        if (transform.position.y > hautEchelle || transform.position.y < basEchelle)
        {
            rb.gravityScale = 8;
            bc.isTrigger = false;
            surEchelle = false;
            IsWalking2 = true;
            IsClimbing2 = false;
        }
        
        if (surEchelle == true && !(Input.GetKey(GoUp)) && !(Input.GetKey(GoDown)))
        {
            IsClimbing2 = true;
        }
    }
}
