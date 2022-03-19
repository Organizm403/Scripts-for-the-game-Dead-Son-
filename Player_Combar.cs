using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combar : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayrs;
    public int attackDamage = 40;
    //Transform PlayerPosition;
    public GameObject[] AttackList;     



    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameObject.Find("Player").GetComponent<PlayerController>().PlayerDead)
        {
            Attack();
        }
        
    }
    void Attack()
    {
        animator.Play("Player_Atack");
        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayrs);
        /*for (int i = 0; i < hitEnemis.Lenght; i++)
        {
            hitEnemis[i].GetComponent<EnemyHP>().TakeDamge(attackDamage);
        }*/
        foreach(Collider2D enemy in hitEnemis)
        {
            //AttackList[0] = hitEnemis[0].GetComponent<EnemyHP>().enemies[2];
            enemy.GetComponent<EnemyHP>().TakeDamge(attackDamage);
        }
    }

    void OnDrawGizmosSelected() 
    {

        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
