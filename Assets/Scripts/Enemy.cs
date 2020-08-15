using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 0;
    public Rigidbody2D rb;
    public int thrust;
    private float attackDelay;
    public float startAttackDelay;
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsEnemy;
    public int damage;
    public Animator animator;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if (attackDelay <= 0)
        {
            animator.SetTrigger("Attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<PlayerMovement>().takeDamage(damage);
            }
            attackDelay = startAttackDelay;
        }
        else
        {
            attackDelay -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        rb.AddForce(Vector2.right * thrust); 
        Debug.Log("Damage Taken!");
    }
}
