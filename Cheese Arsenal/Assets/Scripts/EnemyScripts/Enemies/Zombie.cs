using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemies
{
    private float shotRate = 2.0f;
    private float shotTimer;
    public GameObject projectile;

    protected override void Move()
    {
        base.Move();
    }

    protected override void Attack()
    {
        base.Attack();
        if(shotTimer > shotRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTimer = 0;
        }
    }
}
