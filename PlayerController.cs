using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb;
    public bool PlayerDead = false;
    Transform player;
    public bool MoveSprite = true;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
       // attackeHitBox.SetActive(false);

    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");


        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        if (MoveSprite == false)
             transform.localScale = new Vector2(-1, 1);
            else
             transform.localScale = new Vector2(1, 1);


        

    }
    void FixedUpdate() {
        if (!PlayerDead)
        {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        if (direction.x < 0)
            {
             MoveSprite = false;
            }
            else if (direction.x > 0)
            {
            MoveSprite = true;
            }
        }
        
    }


}
