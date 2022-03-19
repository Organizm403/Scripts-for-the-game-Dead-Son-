using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolerEnemy : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
  //  private Rigidbody2D rb;
    bool moveingRight;
    Transform player;
    public float stopingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;
    public Animator animator;
    public bool EnemyHit;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetFloat("Speed", speed);



    }

    void Update()
    {

        if (speed > 0)
        {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stopingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stopingDistance)
        {
            goBack = true;
            angry = false;
        }
        }
        


        if (chill == true && EnemyHit == false)
        {
            Chill();
        }
        else if (angry == true && EnemyHit == false)
        {
            Angry();
        }
        else if (goBack == true && EnemyHit == false)
        {
            GoBack();
        }
    
    }

    void Chill()
    {
        
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(-1, 1);


        }
    }

    void Angry()
    {
        

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (transform.position.x < player.position.x)
            {
             transform.localScale = new Vector2(1, 1);
            }
            else
            {
            transform.localScale = new Vector2(-1, 1);
            }
        
    }
    void GoBack()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        if (transform.position.x < player.position.x)
            {
             transform.localScale = new Vector2(1, 1);
            }
            else
            {
            transform.localScale = new Vector2(-1, 1);
            }
    }
}