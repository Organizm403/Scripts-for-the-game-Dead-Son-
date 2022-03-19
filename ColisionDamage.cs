using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDamage : MonoBehaviour
{
    public int collisionDamage = 5;
    public string collisionTag;
    public bool colDamage = false;
    public Animator animator;
    public PatrolerEnemy collDamage;   


    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
            TakeDamge();
        }
    }

    public void TakeDamge()
    {
        collDamage.EnemyHit = true;
        StartCoroutine(toHit());
    }
    IEnumerator toHit()
    {
        animator.SetFloat("Speed", 0);
        animator.Play("SlimeAttack");
        yield return new WaitForSeconds(1f);
        collDamage.EnemyHit = false;
        animator.SetFloat("Speed", 3);
    }
}
