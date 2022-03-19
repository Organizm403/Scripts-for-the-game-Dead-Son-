using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Animator animator;
    public PlayerController Playerdie;

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
           Die();
            
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        Debug.Log("Player diad!");
        Playerdie.PlayerDead = true;
        animator.SetBool("ISDie", true);
        StartCoroutine(TODie());
        this.enabled = false;
    }
    
    IEnumerator TODie()
    {
        yield return new WaitForSeconds(3f);
        Playerdie.PlayerDead = false;
        Application.LoadLevel(0);
    }
}
