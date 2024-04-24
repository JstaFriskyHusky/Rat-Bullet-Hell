using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] protected private float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    protected private Transform target;
    [SerializeField] private float distance;
    private SpriteRenderer sp;
    public GameObject deathEffect;
    
    private void Start()
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        Move();
        TurnDirection();
        Attack();
    }

    // Chase Player
    protected virtual void Move()
    {
        if(Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    // Directional Facing
    private void TurnDirection()
    {
        if(transform.position.x > target.position.x)
        {
            sp.flipX = true;
        } else {
            sp.flipX = false;
        }
    }

    public void TakeDamage(int damage)
    {
        healthPoint -= damage;
        
        if (healthPoint <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        // Create death effect, then destroy this object and its effect
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.1f);
    }

    protected virtual void Attack()
    {
        Debug.Log(enemyName + " is Attacking");
    }
}
