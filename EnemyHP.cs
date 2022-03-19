using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHealth = 20;
    int currentHealth;
    public Animator animator;
    public bool EnemyDead;
    public GameObject[] enemies; 
    public PatrolerEnemy enemi;   

    void Start()
    {
        currentHealth = maxHealth;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        enemi.speed = 0;
        animator.SetFloat("Speed", 0);
        Debug.Log("Enemy diad!");
        EnemyDead = true;
        //Debug.Log(EnemyDead);
        animator.SetBool("IsDead", true);
        animator.Play("SlamiDie");
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(toDie());
        //this.enabled = false;
    }
    IEnumerator toDie()
    {
        yield return new WaitForSeconds(3f);
        EnemyDead = false;
        Destroy(gameObject);
    }
}
