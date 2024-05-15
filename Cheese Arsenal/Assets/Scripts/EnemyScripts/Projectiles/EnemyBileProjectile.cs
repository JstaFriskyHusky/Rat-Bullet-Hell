using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBileProjectile : MonoBehaviour
{
    [SerializeField] private float maxLife = 2.0f;
    private float lifeBtwTimer;



    private void Update()
    {
        lifeBtwTimer += Time.deltaTime;
        if(lifeBtwTimer >= maxLife)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
