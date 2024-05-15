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
    private Collider2D c;
    private Renderer ren;

    private void Start()
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        ren = GetComponent<Renderer>();
        c = GetComponent<Collider2D>();
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
            SetDistance(1000);
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

    // Allows enemy to take damage and die
    public void TakeDamage(int damage)
    {
        healthPoint -= damage;
        
        if (healthPoint <= 0)
        {
            Die();
        }
    }

    // Runs when enemy dies
    void Die()
    {
        Destroy(c);
        SetMoveSpeed(0);
        ren.material.SetColor("_Color", Color.red);
        Invoke("Fade", 0.2f);
        Destroy(gameObject, 0.3f);
    }

    // Enemy fades away after death
    void Fade()
    {
        var col = ren.material.color.a;
        col = 0.25f;
    }

    protected virtual void Attack()
    {
        Debug.Log(enemyName + " is Attacking");
    }

    // Set distance (used to maximize distance after enemy spots player)
    void SetDistance(float d)
    {
        distance = d;
    }

    // Set distance (used to make enemy stop moving when they die)
    void SetMoveSpeed(float ms)
    {
        moveSpeed = ms;
    }
}
